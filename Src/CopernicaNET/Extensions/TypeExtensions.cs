using Arlanet.CopernicaNET.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class TypeExtensions
    {
        public static string GetFriendlyName(this Type type)
        {
            if (type.IsGenericType)
            {
                Type generic = type.GetGenericTypeDefinition();

                return generic.Name.Remove(generic.Name.IndexOf('`'));
            }

            return type.Name;
        }

        public static int GetDatabaseId(this Type type)
        {
            var modelConfiguration = CopernicaSettings.Settings.ModelConfigurations.FirstOrDefault(m => m.Name == type.FullName);
            return modelConfiguration.DatabaseId;
        }

        //public static string GetGenericArgName(this Type type)
        //{
        //    if (type.IsGenericType)
        //    {

        //    }
        //}
    }
}
