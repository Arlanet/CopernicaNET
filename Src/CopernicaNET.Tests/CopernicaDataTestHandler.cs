using System;
using System.Collections.Generic;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Handlers;

namespace Arlanet.CopernicaNET.Tests
{
    public class CopernicaDataTestHandler: ICopernicaDataHandler
    {
        private const string profile = "{\"start\":0,\"limit\":1,\"total\":1,\"data\":[{\"ID\":\"1053\",\"fields\":{\"Name\":\"Arlanet\",\"Email\":\"support@arlanet.com\",\"DatabaseId\":\"14\"},\"interests\":[],\"database\":\"108\",\"secret\":\"0986bd117a5c1d8862082b511d4c33b1\",\"created\":\"2014-12-10 15:08:35\"}]}";

        private const string emptyprofile = "{\"start\":0,\"limit\":0,\"total\":0,\"data\":[]}";

        private const string fields = "{\"start\":0,\"limit\":3,\"total\":3,\"data\":[{\"ID\":\"730\",\"name\":\"Name\",\"type\":\"text\",\"value\":\"\",\"displayed\":true,\"ordered\":false,\"length\":\"50\",\"textlines\":\"1\",\"hidden\":false,\"index\":false},{\"ID\":\"731\",\"name\":\"Email\",\"type\":\"email\",\"value\":\"\",\"displayed\":true,\"ordered\":false,\"length\":\"50\",\"textlines\":\"1\",\"hidden\":false,\"index\":false},{\"ID\":\"732\",\"name\":\"DatabaseId\",\"type\":\"integer\",\"value\":\"0\",\"displayed\":true,\"ordered\":false,\"length\":\"50\",\"textlines\":\"1\",\"hidden\":false,\"index\":false}]}";

        public string GetProfileByKeys(int databaseid, Dictionary<string, string> keys, string accesstoken)
        {
            throw new NotImplementedException();
        }

        public string GetProfileByKey(int databaseid, string keyname, string keyvalue, string accesstoken)
        {
            if (keyvalue == "14")
            {
                return profile;
            }
            else
            {
                return emptyprofile;
            }
            
        }

        public string GetSubProfileByKey(int subprofileid, string keyname, string keyvalue, string accesstoken)
        {
            throw new NotImplementedException();
        }

        public string GetSubProfileByKeys(int subprofileid, Dictionary<string, string> keys, string accesstoken)
        {
            throw new NotImplementedException();
        }

        public void CreateDatabase(string jsondata, string accesstoken)
        {

        }

        public void DeleteProfile(int profileid, string accesstoken)
        {
 
        }

        public void CreateProfile(int databaseid, string jsondata, string accesstoken)
        {
   
        }

        public void CreateSubProfile(int databaseid, int profileid, string jsondata, string accesstoken)
        {
   
        }

        public void UpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken)
        {
     
        }

        public void UpdateSubProfile(int databaseid, string jsondata, string accesstoken)
        {

        }

        public string GetProfileFields(int databaseid, string accesstoken)
        {
            return fields;
        }

        public string GetSubProfileFields(int collectionid, string accesstoken)
        {
            return RequestHandler.Get(string.Format("Collection/{0}/fields?access_token={1}", collectionid, accesstoken));
        }
    }
}
