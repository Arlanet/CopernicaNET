using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Arlanet.CopernicaNET.Types;

namespace Arlanet.CopernicaNET
{
    public class CopernicaDbContext
    {
        public CopernicaDbContext()
        {
            instantiateProperties();
           
        }

        private void instantiateProperties()
        {
            IEnumerable<PropertyInfo> properties = this.GetType().GetProperties().Where(prop => prop.PropertyType.Name == typeof(CoperrnicaProfile<bool>).Name);

            foreach(PropertyInfo property in properties)
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
            
        } 
    }
}
