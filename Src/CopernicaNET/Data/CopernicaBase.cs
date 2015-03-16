using System;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Interfaces.Data;

namespace Arlanet.CopernicaNET.Data
{
    public class CopernicaBase: ICopernicaDataItem
    {
        public int DatabaseId
        {
            get
            {
                Type type = this.GetType();
                var db = type.GetCustomAttribute<CopernicaDatabase>();
                if (db == null)
                    throw new CopernicaException("Database attribute is expected.");
                else
                    return db.Id;
            }
        }
    }
}
