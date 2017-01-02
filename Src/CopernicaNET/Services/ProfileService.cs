using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Interfaces;
using Arlanet.CopernicaNET.Models;
using Arlanet.CopernicaNET.Repositories;
using Arlanet.CopernicaNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Services
{
    internal class ProfileService
    {
        private Reflector Reflector { get; }

        private Database database { get; }

        public ProfileService(Database database)
        {
            this.database = database;
        }

        public void Add<T>(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            
            var repo = new ProfileRepository(database.Id);
            
            repo.Add(jsondata);
        }

        public void Update<T>(T item)
        {

        }

        public void Delete<T>(T item)
        {

        }
    }
}
