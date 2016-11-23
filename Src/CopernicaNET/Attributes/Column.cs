using System;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arlanet.CopernicaNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Column : Attribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Length { get; set; }

        public Column()
        {
            
        }

        public Column(string name) : base()
        {
            this.Name = name;
        }
    }
}
