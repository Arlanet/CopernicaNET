using System;
using System.Linq;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Interfaces.Data;

namespace Arlanet.CopernicaNET.Data
{
	public class CopernicaConfigurableBase : ICopernicaDataItem
	{
		public int DatabaseId
		{
			get
			{
				var type = this.GetType();
				var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);
				if(modelConfiguration == null)
					throw new CopernicaException("Database configuration is expected for model type {0}.", type);

				return modelConfiguration.DatabaseId;

			}
		}
	}
}
