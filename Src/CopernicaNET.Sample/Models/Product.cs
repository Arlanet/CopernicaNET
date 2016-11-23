using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Sample.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Column("TotalPrice")]
        public int Price { get; set; }

    }
}