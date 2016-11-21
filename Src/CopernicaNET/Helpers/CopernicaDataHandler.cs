using System.Collections.Generic;
using System.Linq;
using Arlanet.CopernicaNET.Interfaces.Handlers;

namespace Arlanet.CopernicaNET.Helpers
{
    internal class CopernicaDataHandler : ICopernicaDataHandler
    {
        public string GetProfileByKey(int databaseid, string keyname, string keyvalue, string accesstoken)
        {
            return RequestHandler.Get(string.Format("database/{0}/profiles?access_token={1}&fields[]={2}=={3}", databaseid, accesstoken, keyname, keyvalue));
        }

        public string GetProfileByKeys(int databaseid, Dictionary<string, string> keys, string accesstoken)
        {
            string keyfields = keys.Aggregate("", (current, key) => current + ("&" + key.Key + "==" + key.Value));

            return RequestHandler.Get(string.Format("database/{0}/profiles?access_token={1}&fields[]={2}", databaseid, accesstoken, keyfields));
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
            RequestHandler.Post(string.Format("databases?access_token={0}", accesstoken), "{" + jsondata + "}");
        }

        public void DeleteProfile(int profileid, string accesstoken)
        {
            RequestHandler.Delete(string.Format("profile/{0}?access_token={1}", profileid, accesstoken));
        }

        public void CreateProfile(int databaseid, string jsondata, string accesstoken)
        {
            RequestHandler.Post(string.Format("database/{0}/profiles?access_token={1}", databaseid, accesstoken), jsondata);
        }

        public void CreateSubProfile(int collectionid, int profileid, string jsondata, string accesstoken)
        {
            RequestHandler.Post(string.Format("profile/{0}/subprofiles/{1}?access_token={2}", profileid, collectionid, accesstoken), jsondata);
        }

        public void UpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
            RequestHandler.Put(string.Format("database/{0}/profiles?access_token={1}&fields[]={2}=={3}", databaseid, accesstoken, keyname, keyvalue), jsondata);
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
            return RequestHandler.Get(string.Format("database/{0}/fields?access_token={1}", databaseid, accesstoken));
        }

        public string GetSubProfileFields(int collectionid, string accesstoken)
        {
            return RequestHandler.Get(string.Format("collection/{0}/fields?access_token={1}", collectionid, accesstoken));
        }
    }
}
