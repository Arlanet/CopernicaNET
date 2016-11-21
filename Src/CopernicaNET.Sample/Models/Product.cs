using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Sample.Models
{
    [CopernicaConfigurableDatabase(typeof(Product))]
    [CopernicaConfigurableCollection(typeof(Product))]
    public class Product : CopernicaSubprofile
    {
        [CopernicaKeyField("ProductId", Type = CopernicaFieldTypes.IntField, Length = 50)]
        public int ID { get; set; }

        [CopernicaField("ProductName", Type = CopernicaFieldTypes.TextField, Length = 50)]
        public string Name { get; set; }

        [CopernicaField("Price", Type = CopernicaFieldTypes.IntField, Length = 50)]
        public int Price { get; set; }

    }
}