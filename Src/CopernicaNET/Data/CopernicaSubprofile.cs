using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Data;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Data
{
    [JsonConverter(typeof(JsonFieldsConverter))]
    public class CopernicaSubprofile : CopernicaProfile, ICopernicaSubprofile
    {
        public int CollectionId
        {
            get
            {
                var copernicaCollection = GetType().GetCustomAttribute<CopernicaCollection>();

                if (copernicaCollection == null)
                {
                    throw new CopernicaException("Collection attribute is expected.");
                }

                return copernicaCollection.Id;
            }
        }
    }
}
