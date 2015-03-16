using System;

namespace Arlanet.CopernicaNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CopernicaKeyField : CopernicaField
    {
        public CopernicaKeyField(string name) : base(name)
        {
            
        }
    }
}
