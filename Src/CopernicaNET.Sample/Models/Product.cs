using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Sample.Models
{
    [CopernicaDatabase(108)]
    [CopernicaCollection(733)]
    public class Product : CopernicaSubprofile
    {
        [CopernicaField("Naam", Type = CopernicaFieldTypes.TextField, Length = 50)]
        public string Name { get; set; }

        [CopernicaField("Prijs", Type = CopernicaFieldTypes.IntField, Length = 50)]
        public int Price { get; set; }

    }
}