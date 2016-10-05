using System.Collections.Generic;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;
using ExtensionMethods;
using System;

namespace Arlanet.CopernicaNET.Types
{
    public class CoperrnicaProfile<T>
    {
        private Reflectionist Reflectionist { get; set; }
        private CopernicaSettings CopernicaSettings { get; set; }
        private CopernicaDataHandler DataHandler { get; set; }

        private readonly Type Type;

        public CoperrnicaProfile()
        {
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();
            DataHandler = new CopernicaDataHandler();
            Type = GetType();
        }
        
        public T Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);

            //We want the database id of the generic argument, not the generic itself
            DataHandler.CreateProfile(typeof(T).GetDatabaseId(), jsondata, CopernicaSettings.Settings.AccessToken);

            return item;
        }

        public void Remove(T item)
        {
            DataHandler.DeleteProfile(Reflectionist.GetKey(item), CopernicaSettings.AccessToken);
        }
    }
}
