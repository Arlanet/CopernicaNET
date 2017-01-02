using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Models
{
    public class PagingWrapper<T>
    {
        public int Start { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
