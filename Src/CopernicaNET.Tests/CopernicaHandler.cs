using System.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Handlers;
using Arlanet.CopernicaNET.Tests.Classes;

namespace Arlanet.CopernicaNET.Tests
{
    public class CopernicaHandler : Copernica<CopernicaHandler>, ICopernicaHandlerBase
    {
        public CopernicaHandler()
            : base(ConfigurationManager.AppSettings["CopernicaAccessToken"], new CopernicaDataTestHandler())
        {
            
        }

        public void RegisterDataItems()
        {
            RegisterDataItem(new Person());
        }
    }
}