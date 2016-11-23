using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Tests.Classes
{
    [CopernicaDatabase(108)]
    public class Person : CopernicaProfile
    {
        [CopernicaKeyField("DatabaseId", Type = FieldTypes.IntField, Length = 50)]
        public int ID { get; set; }

        [CopernicaField("Name", Type = FieldTypes.TextField, Length = 50)]
        public string Name { get; set; }

        [CopernicaField("Email", Type = FieldTypes.EmailField, Length = 50)]
        public string Email { get; set; }
    }
}
