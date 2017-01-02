using Arlanet.CopernicaNET.Models;
using Arlanet.CopernicaNET.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Arlanet.CopernicaNET.Utils;

namespace Arlanet.CopernicaNET.Services
{
    internal class DatabaseService
    {
        private Reflector Reflector { get; }

        public IEnumerable<Database> GetDatabases(IEnumerable<PropertyInfo> profiles)
        {
            var databaseIds = Reflector.GetDatabaseIds(profiles);
            
            var repo = new DatabaseRepository();

            return repo.GetDatabases().Where(x => databaseIds.Contains(x.Id));
        }
    }
}
