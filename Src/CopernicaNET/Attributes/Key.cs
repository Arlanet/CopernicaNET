using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class Key : Column
    {
        public Key()
        {
            
        }

        public Key(string name) : base(name)
        {
            
        }
    }
}
