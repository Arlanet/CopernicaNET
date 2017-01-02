using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Constants;
using Arlanet.CopernicaNET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Repositories
{
    internal class ProfileRepository : BaseRepository
    {
        private readonly int DatabaseId;

        public ProfileRepository(int DatabaseId)
        {
            this.DatabaseId = DatabaseId;
        }

        public void Add(string jsondata)
        {
            //Mapping comes here
            string requestUrl = string.Format(ServiceCalls.POST.AddProfile, DatabaseId, _copernicaSettings.AccessToken);
            HttpRequest.Post(requestUrl, jsondata);
        }

        public void UpdateProfile(string fieldName, string fieldValue, string jsondata)
        {
            string requestUrl = string.Format(ServiceCalls.PUT.UpdateProfile, DatabaseId, _copernicaSettings.AccessToken, fieldName, fieldValue);
            HttpRequest.Put(requestUrl, jsondata);
        }

        public void DeleteProfile(int profileid)
        {
            string requestUrl = string.Format(ServiceCalls.POST.DeleteProfile, profileid, _copernicaSettings.AccessToken);
            HttpRequest.Delete(requestUrl);
        }
    }
}
