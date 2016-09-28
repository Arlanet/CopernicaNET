using System.Linq;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Attributes
{
    public class CopernicaConfigurableDatabase : CopernicaDatabase
    {
        public CopernicaConfigurableDatabase()
        {
            var type = GetType();
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);

            if (modelConfiguration == null)
            {
                throw new CopernicaException("Database configuration is expected for model type {0}.", type);
            }

            Id = modelConfiguration.DatabaseId;
        }
    }
}
