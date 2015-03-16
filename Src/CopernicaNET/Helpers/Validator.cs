using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arlanet.CopernicaNET.Attributes;
using Arlanet.CopernicaNET.Data;
using Arlanet.CopernicaNET.Interfaces.Data;

namespace Arlanet.CopernicaNET.Helpers
{
    internal static class Validator
    {
        internal static IEnumerable<CopernicaField> GetObjectFields(ICopernicaDataItem item)
        {
            //Get all the properties containing the CopernicaField attribute
            Type objectType = item.GetType();
            var properties = objectType.GetProperties().Where(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(CopernicaField) || y.GetType() == typeof(CopernicaKeyField)));

            //return all the CoperniceField attributes as CopernicaFields
            IEnumerable<CopernicaField> fields = properties.Select(property => (CopernicaField)property.GetCustomAttribute(typeof(CopernicaField), false)).ToList();
            return fields;
        }

        internal static void CompareFields(IEnumerable<CopernicaField> copernicafields, IEnumerable<CopernicaField> objectfields)
        {
            foreach (CopernicaField objectfield in objectfields)
            {
                CopernicaField copernicafield = copernicafields.FirstOrDefault(y => y.Name == objectfield.Name);

                if (copernicafield == null)
                {
                    throw new CopernicaException(String.Format("The field '{0}' does not match with any field in the copernica database. Make sure the name and database ID are correct.", objectfield.Name));
                }
                if (copernicafield.Length != objectfield.Length && copernicafield.Length != 0 && copernicafield.Length != 0)
                {
                    throw new CopernicaException(String.Format("Field length mismatch on '{0}', the length is '{1}' and should be '{2}'", objectfield.Name, objectfield.Length, copernicafield.Length));
                }
                if (copernicafield.Type != objectfield.Type)
                {
                    throw new CopernicaException(String.Format("Field type mismatch on '{0}', the type is '{1}' and should be '{2}'", objectfield.Name, objectfield.Type, copernicafield.Type));
                }
            }
        }

    }
}
