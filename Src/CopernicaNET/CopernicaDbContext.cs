using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arlanet.CopernicaNET
{
    public class CopernicaDbContext
    {
        internal IEnumerable<PropertyInfo> Properties;

        public CopernicaDbContext()
        {
            InstantiateProperties();
            InitSerializationSettings();
        }

        private void InstantiateProperties()
        {
            IEnumerable<PropertyInfo> properties = this.GetType().GetProperties().Where(prop => prop.PropertyType.Name == typeof(CopernicaProfile<Object>).Name);

            this.Properties = properties;

            foreach(PropertyInfo property in this.Properties)
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
        }

        private void InitSerializationSettings()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new JsonContractResolver() //Use our custom class for property name resolving
            };
        }
    }
}
