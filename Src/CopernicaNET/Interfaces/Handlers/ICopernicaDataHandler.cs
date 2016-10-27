using System.Collections.Generic;

namespace Arlanet.CopernicaNET.Interfaces.Handlers
{
    public interface ICopernicaDataHandler
    {
        string GetProfileByKey(int databaseid, string keyname, string keyvalue, string accesstoken);

        string GetProfileByKeys(int databaseid, Dictionary<string, string> keys, string accesstoken);

        string GetSubProfileByKey(int subprofileid, string keyname, string keyvalue, string accesstoken);

        string GetSubProfileByKeys(int subprofileid, Dictionary<string, string> keys, string accesstoken);

        void CreateDatabase(string jsondata, string accesstoken);

        void DeleteProfile(int profileid, string accesstoken);

        void CreateProfile(int databaseid, string jsondata, string accesstoken);

        void CreateSubProfile(int collectionid, int profileid, string jsondata, string accesstoken);

        void UpdateProfile(int databaseid, string keyname, string keyvalue, string jsondata, string accesstoken);

        void UpdateSubProfile(int databaseid, string jsondata, string accesstoken);
        string GetProfileFields(int databaseid, string accesstoken);
        string GetSubProfileFields(int collectionid, string accesstoken);
    }
}
