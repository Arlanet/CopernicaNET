using System.Collections.Generic;

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
