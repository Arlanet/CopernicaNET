using Arlanet.CopernicaNET.Types;

namespace Arlanet.CopernicaNET.Sample.Models
{
    public class CopernicaContext : CopernicaDbContext
    {
        public CopernicaProfile<Client> Clients { get; set; }
        public CopernicaSubProfile<Product> Products { get; set; }
    }
}