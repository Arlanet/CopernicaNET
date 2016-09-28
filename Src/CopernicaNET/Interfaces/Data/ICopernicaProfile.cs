using System.Collections.Generic;

namespace Arlanet.CopernicaNET.Interfaces.Data
{
    public interface ICopernicaProfile : ICopernicaDataItem
    {
        string GetKeyFieldValue();
        string GetKeyFieldName();
        Dictionary<string, string> GetKeys();
    }
}
