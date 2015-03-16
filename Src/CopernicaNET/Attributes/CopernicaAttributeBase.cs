using System;

namespace Arlanet.CopernicaNET.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CopernicaAttributeBase: Attribute
    {
         public int Id { get; set; }

        public CopernicaAttributeBase(int id)
        {
            Id = id;
        }
    }
}
