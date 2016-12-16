using System.Collections.Generic;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Helpers;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;

namespace Arlanet.CopernicaNET.Types
{
    public class CopernicaProfile<T> where T : class, new()
    {
        private Reflectionist Reflectionist { get; }
        private CopernicaSettings CopernicaSettings { get; }
        private CopernicaDataHandler CopernicaDatabase { get; }

        private int DatabaseId { get; }

        public CopernicaProfile()
        {
            Reflectionist = new Reflectionist();
            CopernicaSettings = new CopernicaSettings();

            DatabaseId = Reflectionist.GetDatabaseId(typeof(T));
            CopernicaDatabase = new CopernicaDataHandler(CopernicaSettings.Settings.AccessToken, DatabaseId);
        }
        
        public T Add(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            CopernicaDatabase.AddProfile(jsondata);

            return item;
        }

        public void Update(T item)
        {
            string jsondata = JsonConvert.SerializeObject(item);
            //string idName = Reflectionist.GetKey

            //CopernicaDatabase.UpdateProfile(jsondata, );
        }

        public void Remove(T item)
        {
            CopernicaDatabase.DeleteProfile(Reflectionist.GetKey(item));
        }

        //TODO: Further research lamba expressions
        public IEnumerable<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            var expression = (BinaryExpression)predicate.Body;
            var fieldName = (expression.Left as MemberExpression).Member.Name;
            var fieldValue = (expression.Right as ConstantExpression).Value;
            //DataHandler.GetProfileByField(name, name);
            return new List<T>();
        } 
    }
}
