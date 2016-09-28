using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Interfaces.Data;

namespace Arlanet.CopernicaNET.Data
{
    public class CopernicaBase: ICopernicaDataItem
    {
        public int DatabaseId
        {
            get
            {
                var copernicaDatabase = GetType().GetCustomAttribute<CopernicaDatabase>();

                if (copernicaDatabase == null)
                {
                    throw new CopernicaException("Database attribute is expected.");
                }

                return copernicaDatabase.Id;
            }
        }
    }
}
