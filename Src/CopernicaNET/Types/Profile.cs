using System.Collections.Generic;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Types
{
    public class CoperrnicaProfile<T>
    {
        private static Reflectionist Reflectionist { get; set; }
        private static CopernicaSettings CopernicaSettings { get; set; }
        private static CopernicaDataHandler DataHandler { get; set; }

        static CoperrnicaProfile()
        {
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();
            DataHandler = new CopernicaDataHandler();
        }
        
        public T Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);

            DataHandler.CreateProfile(Reflectionist.GetKey(item), jsondata, CopernicaSettings.AccessToken);

            return item;
        }

        public static void Remove(T item)
        {
            DataHandler.DeleteProfile(Reflectionist.GetKey(item), CopernicaSettings.AccessToken);
        }
    }

    public class CopProfile<T>: List<T>
    {
        private Reflectionist Reflectionist { get; set; }
        private CopernicaSettings CopernicaSettings { get; set; }
        private CopernicaDataHandler DataHandler { get; set; }

        public CopProfile()
        {
            
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();
            DataHandler = new CopernicaDataHandler();
        }

        public new void Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            
            DataHandler.CreateProfile(Reflectionist.GetKey(item), jsondata, CopernicaSettings.AccessToken);

            base.Add(item);
        }

        public new void Remove(T item)
        {
            DataHandler.DeleteProfile(Reflectionist.GetKey(item), CopernicaSettings.AccessToken);

            base.Remove(item);
        }
    }
}
