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
            return RequestHandler.Get(string.Format("collection/{0}/subprofiles?access_token={1}&fields[]={2}=={3}", subprofileid, accesstoken, keyname, keyvalue));
        }

        public string GetSubProfileByKeys(int subprofileid, Dictionary<string, string> keys, string accesstoken)
        {
            string keyfields = keys.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));

            return RequestHandler.Get(string.Format("collection/{0}/subprofiles?access_token={1}&fields[]={2}", subprofileid, accesstoken, keyfields));
        }

        public void CreateDatabase(string jsondata, string accesstoken)
        {
            string keyfields = fields.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));
            string requestUrl = string.Format(DatabaseCalls.GET.GetProfileByFields, DatabaseId, Accesstoken, keyfields);
            
            return RequestHandler.Get(requestUrl);
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

        public void CreateProfile(string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.CreateProfile, DatabaseId, Accesstoken);
            RequestHandler.Post(requestUrl, jsondata);
        }

        public void CreateSubProfile(int collectionid, int profileid, string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.POST.CreateSubProfile, profileid, collectionid, Accesstoken);
            RequestHandler.Post(requestUrl, jsondata);
        }

        public void UpdateProfile(string fieldName, string fieldValue, string jsondata)
        {
            string requestUrl = string.Format(DatabaseCalls.PUT.UpdateProfile, DatabaseId, Accesstoken, fieldName, fieldValue);
            RequestHandler.Put(requestUrl, jsondata);
        }

        public void UpdateSubProfile(int databaseid, string jsondata, string accesstoken)
        {
            RequestHandler.Post(string.Format("subprofile/{0}/fields?access_token={1}", databaseid, accesstoken), jsondata);
        }

        public void CreateOrUpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            RequestHandler.Put(string.Format("database/{0}/profiles?access_token={1}&fields[]={2}=={3}&create=true", databaseid, accesstoken, keyname, keyvalue), jsondata);
        }

        public void CreateOrUpdateSubProfile(int collectionid, int profileid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            RequestHandler.Put(string.Format("profile/{0}/subprofiles/{1}?access_token={2}&fields[]={3}=={4}&create=true", profileid, collectionid, accesstoken, keyname, keyvalue), jsondata);
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
