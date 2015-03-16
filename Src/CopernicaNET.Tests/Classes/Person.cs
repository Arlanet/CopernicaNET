using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Tests.Classes
{
    [CopernicaDatabase(108)]
    public class Person : CopernicaProfile
    {
        [CopernicaKeyField("DatabaseId", Type = CopernicaFieldTypes.IntField, Length = 50)]
        public int ID { get; set; }

        [CopernicaField("Name", Type = CopernicaFieldTypes.TextField, Length = 50)]
        public string Name { get; set; }

        [CopernicaField("Email", Type = CopernicaFieldTypes.EmailField, Length = 50)]
        public string Email { get; set; }
    }
}
