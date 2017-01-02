using System.Collections.Generic;
using Arlanet.CopernicaNET.Configuration;
using Arlanet.CopernicaNET.Utils;
using Arlanet.CopernicaNET.Services;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using Arlanet.CopernicaNET.Models;

namespace Arlanet.CopernicaNET.Types
{
    public class CopernicaProfile<T> : BaseProfile where T : class, new()
    {
        private ProfileService ProfileService { get; }

        private Database Database { get; set; }

        private IEnumerable<Field> Fields { get; set; }

        public CopernicaProfile()
        {
            ProfileService = new ProfileService(Database);
        }
        
        public T Add(T item)
        {
            ProfileService.Add(item);

            return item;
        }

        public void Update(T item)
        {
            ProfileService.Update(item);
        }

        public void Remove(T item)
        {
            ProfileService.Delete(item);
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
