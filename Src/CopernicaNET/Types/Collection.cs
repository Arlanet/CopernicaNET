using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Types
{
    public class CopCollection<T> : List<T>
    {
        public new void Add(T item)
        {
            base.Add(item);
        }

        public new void Remove(T item)
        {
            base.Remove(item);
        }
    }
}
