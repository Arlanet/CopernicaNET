using System;
using System.Linq;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Arlanet.CopernicaNET.Helpers
{
    public class JsonFieldsConverter : JsonConverter
    {
        
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        //This json converter is used to map the actual names that are given in the CopernicaField attributes.
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //TODO: Cleanup!

            // Load JObject from stream and get the data object, it's where the actual information is.
            JObject jObject = JObject.Load(reader);
            var data = jObject["data"];

            //If data is empty the REST api returned nothing
            if(data.FirstOrDefault() == null)
                throw new CopernicaException("Data is empty");

            //This part is needed when retrieving the fields in order to validate the given object.
            if (objectType.Name == "CopernicaField")
            {
                //Create a list of CopernicaField to return
                return data.Select(item => new CopernicaField(item["name"].ToString())
                {
                    //All we need to know is the Name, Length and Type to validate.
                    Length = item["length"] == null ? 0 : (int)item["length"], 
                    Type = (string) item["type"]
                }).ToList();
            }

            //Parse the data until only the object is left.
            dynamic a = JObject.Parse(data.First.ToString());
            dynamic b = JObject.Parse(a["fields"].ToString());
            var obj = Activator.CreateInstance(objectType);
            var jobject = new JObject(b);

            //Get all the properties and loop trough them. Then add all the properties with the correct names from je object.
            //This makes sure the mapping is right when deserializing the object.
            var properties = objectType.GetProperties().Where(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaField) || y.GetType() == typeof(CopernicaKeyField)));
            var jobj = new JObject();
            foreach (var property in properties)
            {
                jobj.Add(property.Name, jobject[property.GetCustomAttribute<CopernicaField>().Name]);
            }

            //Populate the correct data in the object.
            JsonReader objreader = jobj.CreateReader();
            serializer.Populate(objreader, obj);

            return obj;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            //Get all the properties that contain either the CopernicaField of the CopernicaKeyField attribute.
            var properties = value.GetType().GetProperties().Where(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaField) || y.GetType() == typeof(CopernicaKeyField)));
            
            //Loop through the properties and add the CopernicaField name + property value to the JObject.
            //This makes sure the mapping is right when serializing the object.
            JObject obj = new JObject();
            foreach (var property in properties)
            {
                obj.Add(property.GetCustomAttribute<CopernicaField>().Name, property.GetValue(value) == null ? "" : property.GetValue(value).ToString());
            }
            obj.WriteTo(writer);

            writer.Flush();
        }
    }
}
