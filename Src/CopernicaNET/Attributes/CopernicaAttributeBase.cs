using System;

namespace Arlanet.CopernicaNET.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public abstract class CopernicaAttributeBase : Attribute
    {
        public int Id { get; set; }

        protected CopernicaAttributeBase()
        {
            //Do nothing
        }

        protected CopernicaAttributeBase(int id)
        {
            Id = id;
        }
    }
}
