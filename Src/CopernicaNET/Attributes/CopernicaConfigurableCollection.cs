using System;
using System.Linq;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Attributes
{
    public class CopernicaConfigurableCollection : CopernicaCollection
    {
        public CopernicaConfigurableCollection(Type type)
        {
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);

            if (modelConfiguration == null)
            {
                throw new CopernicaException("Database configuration is expected for model type {0}.", type);
            }

            Id = modelConfiguration.CollectionId;
        }
    }
}
