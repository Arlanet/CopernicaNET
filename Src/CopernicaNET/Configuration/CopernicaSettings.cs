using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Configuration
{
	public class CopernicaSettings : ConfigurationSection
	{
		/// <summary>
		/// 
		/// </summary>
		private static CopernicaSettings _settings = ConfigurationManager.GetSection("copernicanet") as CopernicaSettings;

		public static CopernicaSettings Settings
		{
			get
			{
				if (_settings == null)
					throw new ConfigurationErrorsException("Arlanet CopernicaNET settings not configured!");
				return _settings;
			}
		}

		/// <summary>
		/// The client username for logging on to Intersolve
		/// </summary>
		[ConfigurationProperty("accesstoken", IsRequired = false)]
		public string AccessToken
		{
			get
			{
				return (string)base["accesstoken"];
			}
		}

		[ConfigurationProperty("models")]
		[ConfigurationCollection(typeof(ModelConfigurationElementCollection), AddItemName = "model")]
		public ModelConfigurationElementCollection ModelConfigurations
		{
			get { return (ModelConfigurationElementCollection)base["models"]; }
		}

	}

	public class ModelConfiguration : ConfigurationElement
	{
		public ModelConfiguration()
		{

		}

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("collectionid", IsRequired = false)]
		public int CollectionId
		{
			get { return (int)this["collectionid"]; }
			set { this["collectionid"] = value; }
		}

		[ConfigurationProperty("databaseid", IsRequired = true)]
		public int DatabaseId
		{
			get { return (int)this["databaseid"]; }
			set { this["databaseid"] = value; }
		}
	}

	public class ModelConfigurationElementCollection : ConfigurationElementCollection, IEnumerable<ModelConfiguration>
	{
		public ModelConfigurationElementCollection()
		{
			var myElement = (ModelConfiguration)CreateNewElement();
			Add(myElement);
		}

		public void Add(ModelConfiguration customElement)
		{
			BaseAdd(customElement);
		}

		protected override void BaseAdd(ConfigurationElement element)
		{
			base.BaseAdd(element, false);
		}

		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.AddRemoveClearMap;
			}
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ModelConfiguration();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ModelConfiguration)element).Name;
		}

		public ModelConfiguration this[int Index]
		{
			get
			{
				return (ModelConfiguration)BaseGet(Index);
			}
			set
			{
				if (BaseGet(Index) != null)
				{
					BaseRemoveAt(Index);
				}
				BaseAdd(Index, value);
			}
		}

		new public ModelConfiguration this[string Name]
		{
			get
			{
				return (ModelConfiguration)BaseGet(Name);
			}
		}

		public int indexof(ModelConfiguration element)
		{
			return BaseIndexOf(element);
		}

		public void Remove(ModelConfiguration url)
		{
			if (BaseIndexOf(url) >= 0)
				BaseRemove(url.Name);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
		}

		public void Clear()
		{
			BaseClear();
		}

		public new IEnumerator<ModelConfiguration> GetEnumerator()
		{
			var count = base.Count;
			for (var i = 0; i < count; i++)
			{
				yield return base.BaseGet(i) as ModelConfiguration;
			}
		}
	}
}
