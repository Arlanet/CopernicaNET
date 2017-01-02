using Arlanet.CopernicaNET.Constants;
using Arlanet.CopernicaNET.Models;
using Arlanet.CopernicaNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Repositories
{
    internal class DatabaseRepository : BaseRepository
    {
        public IEnumerable<Database> GetDatabases()
        {
            string requestUrl = string.Format(ServiceCalls.POST.AddProfile, _copernicaSettings.AccessToken);
            string jsonResponse = HttpRequest.Get(requestUrl);

            IEnumerable<Database> databases = JsonConvert.DeserializeObject<IEnumerable<Database>>(jsonResponse);

            return databases;
        }
    }
}
