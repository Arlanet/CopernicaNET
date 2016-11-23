using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Arlanet.CopernicaNET.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arlanet.CopernicaNET.Helpers
{
    public class JsonContractResolver : DefaultContractResolver
    {
        public JsonContractResolver()
        {
            
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            string propertyName = property.PropertyType.GetCustomAttribute<Column>().Name;

            if (!string.IsNullOrEmpty(propertyName))
            {
                property.PropertyName = propertyName;
            }

            return property;
        }
    }
}
