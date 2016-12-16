using System.Collections.Generic;
using System.Linq;
using Arlanet.CopernicaNET.Constants;
using Arlanet.CopernicaNET.Utils;

namespace Arlanet.CopernicaNET.Services
{
    internal class CopernicaService
    {
        private string Accesstoken { get; }
        private int DatabaseId { get; }

        public CopernicaService(string accesstoken, int databaseId)
        {
            Accesstoken = accesstoken;
            DatabaseId = databaseId;
        }

        public string GetProfileByField(string fieldName, string fieldValue)
        {
            string requestUrl = string.Format(ServiceCalls.GET.GetProfileByField, DatabaseId, Accesstoken, fieldName, fieldValue);

            return HttpRequest.Get(requestUrl);
        }

        public string GetSubProfileByKey(int subprofileid, string keyname, string keyvalue, string accesstoken)
        {
            string requestUrl = string.Format(ServiceCalls.GET.GetSubProfileByKey, subprofileid, accesstoken, keyname,
                keyvalue);

            return HttpRequest.Get(requestUrl);
        }

        public string GetSubProfileByKeys(int subprofileid, Dictionary<string, string> keys, string accesstoken)
        {
            string keyfields = keys.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));

            string requestUrl = string.Format(ServiceCalls.GET.GetSubProfileByKeys, subprofileid, accesstoken,
                keyfields);

            return HttpRequest.Get(requestUrl);
        }

        public void CreateDatabase(string jsondata, string accesstoken)
        {
            //string keyfields = fields.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));
            //string requestUrl = string.Format(DatabaseCalls.GET.GetProfileByFields, DatabaseId, Accesstoken, keyfields);
            
            //return RequestHandler.Get(requestUrl);
        }

        public void CreateDatabase(string jsondata)
        {
            string requestUrl = string.Format(ServiceCalls.POST.CreateDatabase, Accesstoken);
            HttpRequest.Post(requestUrl, "{" + jsondata + "}");
        }

        public void DeleteProfile(int profileid)
        {
            string requestUrl = string.Format(ServiceCalls.POST.DeleteProfile, profileid, Accesstoken);
            HttpRequest.Delete(requestUrl);
        }

        public void AddProfile(string jsondata)
        {
            string requestUrl = string.Format(ServiceCalls.POST.AddProfile, DatabaseId, Accesstoken);
            HttpRequest.Post(requestUrl, jsondata);
        }

        public void AddSubProfile(int collectionid, int profileid, string jsondata)
        {
            string requestUrl = string.Format(ServiceCalls.POST.AddSubProfile, profileid, collectionid, Accesstoken);
            HttpRequest.Post(requestUrl, jsondata);
        }

        public void UpdateProfile(string fieldName, string fieldValue, string jsondata)
        {
            string requestUrl = string.Format(ServiceCalls.PUT.UpdateProfile, DatabaseId, Accesstoken, fieldName, fieldValue);
            HttpRequest.Put(requestUrl, jsondata);
        }

        public void UpdateSubProfile(int databaseid, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(ServiceCalls.POST.UpdateSubProfile, databaseid, accesstoken);
            HttpRequest.Post(requestUrl, jsondata);
        }

        public void AddOrUpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(ServiceCalls.PUT.AddOrUpdateProfile, databaseid, accesstoken, keyname,
                keyvalue);

            HttpRequest.Put(requestUrl, jsondata);
        }

        public void AddOrUpdateSubProfile(int collectionid, int profileid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(ServiceCalls.PUT.AddOrUpdateSubProfile, profileid, collectionid,
                accesstoken, keyname, keyvalue);

            HttpRequest.Put(requestUrl, jsondata);
        }

        public string GetProfileFields(int databaseid, string accesstoken)
        {
            string requestUrl = string.Format(ServiceCalls.GET.GetProfileFields, DatabaseId, Accesstoken);
            return HttpRequest.Get(requestUrl);
        }

        public string GetSubProfileFields(int collectionid)
        {
            string requestUrl = string.Format(ServiceCalls.GET.GetSubProfileFields, collectionid, Accesstoken);
            return HttpRequest.Get(requestUrl);
        }
    }
}
