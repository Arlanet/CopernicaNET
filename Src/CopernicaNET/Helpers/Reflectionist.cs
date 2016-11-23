using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;
using Arlanet.CopernicaNET.Configuration;

namespace Arlanet.CopernicaNET.Helpers
{
    public class Reflectionist
    {
        public int GetKey<T>(T item)
        {
            PropertyInfo[] properties = item.GetType().GetProperties();
            PropertyInfo property =
                properties.FirstOrDefault(
                    x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(Key)));

            if (property == null) //There is no property with a key attribute
            {
                property = properties.FirstOrDefault(x => x.Name == "ID");

                if (property == null)
                    throw new CopernicaException("Key field has no value.");
            }

            string keyValue = property.GetValue(item).ToString();

            return Int32.Parse(keyValue);
        }
        
        public int GetDatabaseId(Type type)
        {
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);

            if(modelConfiguration == null)
                throw new CopernicaException($"Type '{{type.Fullname}}' is not correctly configured");
            
            return modelConfiguration.DatabaseId;
        }
    }
}
