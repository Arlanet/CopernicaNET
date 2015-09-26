using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Data;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Data
{
	[JsonConverter(typeof(JsonFieldsConverter))]
	public class CopernicaConfigurableSubProfile : CopernicaConfigurableBase, ICopernicaSubprofile
	{

		public int CollectionId
		{
			get
			{
				var type = this.GetType();
				var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);
				if (modelConfiguration == null)
					throw new CopernicaException("Collection configuration is expected for model type {0}.", type);

				return modelConfiguration.CollectionId;
			}
		}
	}
}
