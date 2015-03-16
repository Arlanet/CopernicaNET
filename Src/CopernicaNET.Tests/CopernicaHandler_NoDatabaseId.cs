using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Handlers;
using Arlanet.CopernicaNET.Tests.Classes;

namespace Arlanet.CopernicaNET.Tests
{
    public class CopernicaHandler_NoDatabaseId : Copernica<CopernicaHandler>, ICopernicaHandlerBase
    {
        public CopernicaHandler_NoDatabaseId()
            : base("0a163264b482e5e8b867fa0b79af7ceea97d7ec6c9d22e6cc1815b2d292819ad55eb97e69b59c1a4e64095ecebc0553734424a5f959321499bce44d498778570", new CopernicaDataTestHandler())
        {
            
        }

        public void RegisterDataItems()
        {
            RegisterDataItem(new Person_NoDatabaseId());
        }
    }
}