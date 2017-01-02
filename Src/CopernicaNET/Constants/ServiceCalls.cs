namespace Arlanet.CopernicaNET.Constants
{
    public static class ServiceCalls
    {
        public static class POST
        {
            public const string DeleteProfile = "profile/{0}?access_token={1}";
            public const string AddProfile = "database/{0}/profiles?access_token={1}";
            public const string AddSubProfile = "profile/{0}/subprofiles/{1}?access_token={2}";
            public const string CreateDatabase = "databases?access_token={0}";
            public const string UpdateSubProfile = "subprofile/{0}/fields?access_token={1}";
        }

        public static class GET
        {
            public const string GetDatabases = "databases?access_token={0}";

            public const string GetProfileByField = "database/{0}/profiles?access_token={1}&fields[]={2}=={3}";
            public const string GetProfileByFields = "database/{0}/profiles?access_token={1}&fields[]={2}";
            public const string GetProfileFields = "database/{0}/fields?access_token={1}";
            public const string GetSubProfileFields = "collection/{0}/fields?access_token={1}";
            public const string GetSubProfileByKey = "collection/{0}/subprofiles?access_token={1}&fields[]={2}=={3}";
            public const string GetSubProfileByKeys = "collection/{0}/subprofiles?access_token={1}&fields[]={2}";
        }

        public static class PUT
        {
            public const string UpdateProfile = "database/{0}/profiles?access_token={1}&fields[]={2}=={3}";
            public const string AddOrUpdateSubProfile = "profile/{0}/subprofiles/{1}?access_token={2}&fields[]={3}=={4}&create=true";
            public const string AddOrUpdateProfile = "database/{0}/profiles?access_token={1}&fields[]={2}=={3}&create=true";
        }
    }
}
