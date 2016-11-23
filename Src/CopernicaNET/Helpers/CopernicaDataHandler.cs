using System.Collections.Generic;
using System.Linq;
using Arlanet.CopernicaNET.Data;
using Arlanet.CopernicaNET.Interfaces.Handlers;

namespace Arlanet.CopernicaNET.Helpers
{
    internal class CopernicaDataHandler
    {
        private string Accesstoken { get; }
        private int DatabaseId { get; }

        public CopernicaDataHandler(string accesstoken, int databaseId)
        {
            Accesstoken = accesstoken;
            DatabaseId = databaseId;
        }

        public string GetProfileByField(string fieldName, string fieldValue)
        {
            string requestUrl = string.Format(DatabaseCalls.GET.GetProfileByField, DatabaseId, Accesstoken, fieldName, fieldValue);

            return RequestHandler.Get(requestUrl);
        }

        public string GetSubProfileByKey(int subprofileid, string keyname, string keyvalue, string accesstoken)
        {
            string requestUrl = string.Format(DatabaseCalls.GET.GetSubProfileByKey, subprofileid, accesstoken, keyname,
                keyvalue);

            return RequestHandler.Get(requestUrl);
        }

        public string GetSubProfileByKeys(int subprofileid, Dictionary<string, string> keys, string accesstoken)
        {
            string keyfields = keys.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));

            string requestUrl = string.Format(DatabaseCalls.GET.GetSubProfileByKeys, subprofileid, accesstoken,
                keyfields);

            return RequestHandler.Get(requestUrl);
        }

        public void CreateDatabase(string jsondata, string accesstoken)
        {
            //string keyfields = fields.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));
            //string requestUrl = string.Format(DatabaseCalls.GET.GetProfileByFields, DatabaseId, Accesstoken, keyfields);
            
            //return RequestHandler.Get(requestUrl);
        }

        public void CreateDatabase(string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.CreateDatabase, Accesstoken);
            RequestHandler.Post(requestUrl, "{" + jsondata + "}");
        }

        public void DeleteProfile(int profileid)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.DeleteProfile, profileid, Accesstoken);
            RequestHandler.Delete(requestUrl);
        }

        public void AddProfile(string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.AddProfile, DatabaseId, Accesstoken);
            RequestHandler.Post(requestUrl, jsondata);
        }

        public void AddSubProfile(int collectionid, int profileid, string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.AddSubProfile, profileid, collectionid, Accesstoken);
            RequestHandler.Post(requestUrl, jsondata);
        }

        public void UpdateProfile(string fieldName, string fieldValue, string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.PUT.UpdateProfile, DatabaseId, Accesstoken, fieldName, fieldValue);
            RequestHandler.Put(requestUrl, jsondata);
        }

        public void UpdateSubProfile(int databaseid, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.UpdateSubProfile, databaseid, accesstoken);
            RequestHandler.Post(requestUrl, jsondata);
        }

        public void AddOrUpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(DatabaseCalls.PUT.AddOrUpdateProfile, databaseid, accesstoken, keyname,
                keyvalue);

            RequestHandler.Put(requestUrl, jsondata);
        }

        public void AddOrUpdateSubProfile(int collectionid, int profileid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            string requestUrl = string.Format(DatabaseCalls.PUT.AddOrUpdateSubProfile, profileid, collectionid,
                accesstoken, keyname, keyvalue);

            RequestHandler.Put(requestUrl, jsondata);
        }

        public string GetProfileFields(int databaseid, string accesstoken)
        {
            string requestUrl = string.Format(DatabaseCalls.GET.GetProfileFields, DatabaseId, Accesstoken);
            return RequestHandler.Get(requestUrl);
        }

        public string GetSubProfileFields(int collectionid)
        {
            string requestUrl = string.Format(DatabaseCalls.GET.GetSubProfileFields, collectionid, Accesstoken);
            return RequestHandler.Get(requestUrl);
        }
    }
}
