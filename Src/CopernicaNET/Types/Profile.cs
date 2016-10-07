using System.Collections.Generic;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;
using System;

namespace Arlanet.CopernicaNET.Types
{
    public class CopernicaProfile<T> where T : class, new()
    {
        private Reflectionist Reflectionist { get; }
        private CopernicaSettings CopernicaSettings { get; }
        private CopernicaDataHandler DataHandler { get; }

        private int DatabaseId { get; }

        public CopernicaProfile()
        {
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();
            DataHandler = new CopernicaDataHandler();
            DatabaseId = Reflectionist.GetDatabaseId(typeof (T));
        }
        
        public T Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            DataHandler.CreateProfile(DatabaseId, jsondata, CopernicaSettings.Settings.AccessToken);

            return item;
        }

        public void Remove(T item)
        {
            DataHandler.DeleteProfile(Reflectionist.GetKey(item), CopernicaSettings.AccessToken);
        }
    }
}
