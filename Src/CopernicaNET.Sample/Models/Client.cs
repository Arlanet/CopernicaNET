using System.Collections.Generic;
using Arlanet.CopernicaNET.Attributes;

namespace Arlanet.CopernicaNET.Sample.Models
{
    //[CopernicaConfigurableDatabase(typeof(Client))]
    //public class Client : CopernicaProfile
    //{
    //    /// Sets the Copernica field 'DatabaseId' as the identifier. Which will be used when updating.
    //    [CopernicaKeyField("DatabaseId", Type = CopernicaFieldTypes.IntField, Length = 50)]
    //    public int ID { get; set; }

    //    [CopernicaField("Name", Type = CopernicaFieldTypes.TextField, Length = 255)]
    //    public string Name { get; set; }

    //    [CopernicaField("Email", Type = CopernicaFieldTypes.EmailField, Length = 100)]
    //    public string Email { get; set; }
    //}

    public class Client
    {
        [Key]
        [Column("DatabaseId")]
        public int DatabaseId { get; set; }
        
        [Column]
        public string Name { get; set; }

        [Column("EmailAddress")]
        public string Email { get; set; }

        //[Collection(5)]
        //public IEnumerable<Product> Products { get; set; }
    }
}