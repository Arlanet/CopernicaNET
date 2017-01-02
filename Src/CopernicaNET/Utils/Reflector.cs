using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Configuration;

namespace Arlanet.CopernicaNET.Utils
{
    public class Reflector
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

        public IEnumerable<Object> GetFields()
        {
            return new List<Object>();
        }
        
        public int GetDatabaseId(Type type)
        {
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);

            if(modelConfiguration == null)
                throw new CopernicaException($"Type '{{type.Fullname}}' is not correctly configured");
            
            return modelConfiguration.DatabaseId;
        }

        public int GetDatabaseId<T>(T item)
        {
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == item.GetType().FullName);

            if (modelConfiguration == null)
                throw new CopernicaException($"Type '{{type.Fullname}}' is not correctly configured");

            return modelConfiguration.DatabaseId;
        }

        public IEnumerable<int> GetDatabaseIds(IEnumerable<PropertyInfo> profiles)
        {
            var databaseIds = new List<int>();

            foreach (var profile in profiles)
            {
                var profileType = profile.GetType().GetGenericArguments().Single();

                databaseIds.Add(GetDatabaseId(profileType));
            }

            return databaseIds;
        }
    }
}
