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

        public string GetProfileByFields(Dictionary<string, string> fields)
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

        public string GetProfileFields(int databaseid)
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
