using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Arlanet.CopernicaNET.Interfaces;
using Arlanet.CopernicaNET.Utils;
using Arlanet.CopernicaNET.Models;
using Arlanet.CopernicaNET.Services;

namespace Arlanet.CopernicaNET
{
    public class CopernicaDbContext
    {
        internal IEnumerable<Database> Databases { get; set; }

        private static Reflector reflector = new Reflector();

        public CopernicaDbContext()
        {
            Configuration();
        }

        private void Configuration()
        {
            ConfigureProperties();
            ConfigureJsonSerialization();
        }

        private void ConfigureProperties()
        {
            var profiles = this.GetProfiles();

            var dbService = new DatabaseService();

            this.Databases = dbService.GetDatabases(profiles);

            ConfigureProfiles(profiles);
        }

        private IEnumerable<PropertyInfo> GetProfiles()
        {
            IEnumerable<PropertyInfo> profiles = this.GetType().GetProperties()
                .Where(prop => prop.PropertyType.Name == typeof(CopernicaProfile<Object>).Name);
            
            return profiles;
        }

        private void ConfigureProfiles(IEnumerable<PropertyInfo> profiles)
        {
            foreach (PropertyInfo profile in profiles)
            {
                profile.SetValue(this, Activator.CreateInstance(profile.PropertyType));

                //Set database values for profiles
                var dbProperty = typeof(CopernicaProfile<Object>).GetProperty("Database");
                var dbId = reflector.GetDatabaseId(profile);

                dbProperty.SetValue(profile, this.Databases.FirstOrDefault(x => x.Id == dbId));
            }
        }

        private void ConfigureJsonSerialization()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new JsonContractResolver()
            };
        }
    }
}
