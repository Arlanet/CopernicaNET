using System.Collections.Generic;
using System.Configuration;

namespace Arlanet.CopernicaNET.Configuration
{
	public class CopernicaSettings : ConfigurationSection
	{
		private static readonly CopernicaSettings _settings = ConfigurationManager.GetSection("copernicanet") as CopernicaSettings;

		public static CopernicaSettings Settings
		{
			get
			{
			    if (_settings == null)
			    {
			        throw new ConfigurationErrorsException("Arlanet CopernicaNET settings not configured!");
			    }

				return _settings;
			}
		}

		[ConfigurationProperty("accesstoken", IsRequired = false)]
		public string AccessToken
		{
			get
			{
				return (string)base["accesstoken"];
			}
		}

        [ConfigurationProperty("apiurl", IsRequired = false)]
        public string ApiUrl
        {
            get
            {
                return (string)base["apiurl"];
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

		public ModelConfiguration this[int index]
		{
			get
			{
				return (ModelConfiguration)BaseGet(index);
			}
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}

		public new ModelConfiguration this[string name]
		{
			get
			{
				return (ModelConfiguration)BaseGet(name);
			}
		}

		public int IndexOf(ModelConfiguration element)
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
			for (var i = 0; i < Count; i++)
			{
				yield return BaseGet(i) as ModelConfiguration;
			}
		}
	}
}
