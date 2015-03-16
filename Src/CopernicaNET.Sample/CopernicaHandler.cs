using System.Configuration;
using Arlanet.CopernicaNET.Sample.Models;
using Arlanet.CopernicaNET.Interfaces.Handlers;

namespace Arlanet.CopernicaNET.Sample
{
    public class CopernicaHandler : Copernica<CopernicaHandler>, ICopernicaHandlerBase
    {
        public CopernicaHandler()
            : base(ConfigurationManager.AppSettings["CopernicaAccessToken"])
        {

        }

        public void RegisterDataItems()
        {
            RegisterDataItem(new Client());
        }
    }
}