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
            Configuration();
        }

        private void Configuration()
        {
            ConfigureProfiles();
            ConfigureJsonSerialization();
        }

        private void ConfigureProfiles()
        {
            IEnumerable<PropertyInfo> properties = this.GetType().GetProperties()
                .Where(prop => prop.PropertyType.Name == typeof(CopernicaProfile<Object>).Name
                            || prop.PropertyType.Name == typeof(CopernicaSubProfile<Object>).Name);

            this.Properties = properties;

            foreach(PropertyInfo property in this.Properties)
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
        }

        private void ConfigureJsonSerialization()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new JsonContractResolver()
            };
        }
    }
}
