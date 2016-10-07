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
            DatabaseId = Reflectionist.GetDatabaseId(typeof(T));
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();
            DataHandler = new CopernicaDataHandler(CopernicaSettings.Settings.AccessToken, DatabaseId);
        }
        
        public T Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            DataHandler.CreateProfile(jsondata);

            return item;
        }

        public void Update(T item)
        {
            
        }

        public void Remove(T item)
        {
            DataHandler.DeleteProfile(Reflectionist.GetKey(item));
        }
    }
}
