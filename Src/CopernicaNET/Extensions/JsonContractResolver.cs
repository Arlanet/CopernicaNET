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
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            string columnName = member.GetCustomAttribute<Column>()?.Name;

            if (!string.IsNullOrEmpty(columnName))
                property.PropertyName = columnName;
            
            return property;
        }
    }
}
