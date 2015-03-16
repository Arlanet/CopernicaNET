using System;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Helpers;
using Arlanet.CopernicaNET.Interfaces.Data;
using Newtonsoft.Json;

namespace Arlanet.CopernicaNET.Data
{
    [JsonConverter(typeof(JsonFieldsConverter))]
    public class CopernicaSubprofile : CopernicaBase, ICopernicaSubprofile
    {
        public int CollectionId
        {
            get
            {
                Type type = this.GetType();
                var db = type.GetCustomAttribute<CopernicaCollection>();
                if (db == null)
                    throw new CopernicaException("Collection attribute is expected.");
                else
                    return db.Id;
            }
        }
    }
}
