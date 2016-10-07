using Arlanet.CopernicaNET.Sample.Models;
using Arlanet.CopernicaNET.Interfaces.Handlers;
using Arlanet.CopernicaNET.Types;

namespace Arlanet.CopernicaNET.Sample
{
    //public class CopernicaHandler : Copernica<CopernicaHandler>, ICopernicaHandlerBase
    //{
    //    public void RegisterDataItems()
    //    {
    //        RegisterDataItem(new Client());
    //    }
    //}

    public class CopernicaContext : CopernicaDbContext
    {
        public CopernicaProfile<Client> Clients { get; set; }
    }
}