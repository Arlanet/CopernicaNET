using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arlanet.CopernicaNET.Data
{
    public static class DatabaseCalls
    {
        public static class POST
        {
            public const string DeleteProfile = "profile/{0}?access_token={1}";
            public const string CreateProfile = "database/{0}/profiles?access_token={1}";
            public const string CreateSubProfile = "profile/{0}/subprofiles/{1}?access_token={2}";
            public const string CreateDatabase = "databases?access_token={0}";
        }

        public static class GET
        {
            public const string GetProfileByField = "database/{0}/profiles?access_token={1}&fields[]={2}=={3}";
            public const string GetProfileByFields = "database/{0}/profiles?access_token={1}&fields[]={2}";
            public const string GetProfileFields = "database/{0}/fields?access_token={1}";
            public const string GetSubProfileFields = "collection/{0}/fields?access_token={1}";
        }

        public static class PUT
        {
            public const string UpdateProfile = "database/{0}/profiles?access_token={1}&fields[]={2}=={3}";
        }
    }
}
