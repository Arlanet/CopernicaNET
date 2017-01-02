using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Models
{
    internal class Database
    {
        public Database(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get; set; }

        public DateTime Created { get; set; }

        public PagingWrapper<Field> Fields { get; set; }

    }
}
