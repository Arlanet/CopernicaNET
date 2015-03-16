using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Sample.Models
{
    [CopernicaDatabase(108)]
    public class Client : CopernicaProfile
    {
        /// Sets the Copernica field 'DatabaseId' as the identifier. Which will be used when updating.
        [CopernicaKeyField("DatabaseId", Type = CopernicaFieldTypes.IntField, Length = 50)]
        public int ID { get; set; }

        [CopernicaField("Name", Type = CopernicaFieldTypes.TextField, Length = 50)]
        public string Name { get; set; }

        [CopernicaField("Email", Type = CopernicaFieldTypes.EmailField, Length = 50)]
        public string Email { get; set; }
    }
}