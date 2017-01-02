using Arlanet.CopernicaNET.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Models
{
    internal class Field
    {
        public int ID { get; set; }

        public string name { get; set; }
        
        public string type { get; set; }

        public string value { get; set; }

        public bool displayed { get; set; }

        public bool ordered { get; set; }

        public int length { get; set; }

        public string textlines { get; set; }

        public bool hidden { get; set; }

        public bool index { get; set; }
    }
}
