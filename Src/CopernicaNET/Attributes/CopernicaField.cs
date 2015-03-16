using System;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Attributes
{
    [JsonConverter(typeof(JsonFieldsConverter))]
    [AttributeUsage(AttributeTargets.Property)]
    public class CopernicaField : Attribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Length { get; set; }
        public bool Required { get; set; }

        public CopernicaField(string name)
        {
            this.Name = name;
        }
    }
}
