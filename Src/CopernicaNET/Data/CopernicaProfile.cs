using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Data;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Data
{
    [JsonConverter(typeof(JsonFieldsConverter))]
    public abstract class CopernicaProfile : CopernicaBase, ICopernicaProfile
    {
        protected CopernicaProfile()
        {
            ValidateFields();
        }

        private void ValidateFields()
        {
            //Get all the properties that contain a CopernicaField or CopernicaKeyField attribute
            PropertyInfo[] properties = GetType().GetProperties();
            IEnumerable<PropertyInfo> propertylist =
                properties.Where(
                    x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaField) || y.GetType() == typeof(CopernicaKeyField)));

            PropertyInfo propertyz =
                properties.FirstOrDefault(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaKeyField)));

            //Validate the properties
            if(propertyz == null)
                throw new CopernicaException("A CopernicaKeyField attribute is expected. This specifies the field that will be used as identifier.");

            if (propertyz.GetCustomAttribute<CopernicaKeyField>().Name.ToUpper() == "ID")
                throw new CopernicaException("Can't use the name 'ID' as a copernica field because it is being used as an identifier.");

            //Check for the database
            if (propertylist.Where(prop => prop.GetCustomAttribute<CopernicaField>() != null).Any(prop => prop.GetCustomAttribute<CopernicaField>().Name == "ID"))
            {
                throw new CopernicaException("Can't use the name 'ID' as a copernica field because it is being used as an identifier.");
            }
        }

        public string GetKeyFieldValue()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            PropertyInfo property =
                properties.FirstOrDefault(
                    x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaKeyField)));
            if (property == null)
            {
                throw new CopernicaException("Key field has no value.");
            }
            return property.GetValue(this).ToString();
        }

        public string GetKeyFieldName()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            PropertyInfo property =
                properties.FirstOrDefault(
                    x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaKeyField)));
            return property.GetCustomAttribute<CopernicaKeyField>().Name;
        }

        public Dictionary<string, string> GetKeys()
        {
            //Retrieve all the CopernicaKeyFields from the current object
            PropertyInfo[] properties = GetType().GetProperties();
            IEnumerable<PropertyInfo> keysproperties = properties.Where(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaKeyField)));

            //Throw an exception if there are not KeyFields found.
            if (keysproperties == null)
            {
                throw new CopernicaException("No key fields were found.");
            }

            //Create a new Dictionary and fill it with the name and value of each key field.
            try
            {
                Dictionary<string, string> keys =
                    keysproperties.ToDictionary(property => property.GetCustomAttribute<CopernicaKeyField>().Name,
                        property => property.GetValue(this).ToString());
                return keys;
            }
            catch (Exception ex)
            {
                throw new CopernicaException("Something went wrong when obtaining the object identifier, make sure the key field is not empty.", ex);
            }
        } 
    }
}
