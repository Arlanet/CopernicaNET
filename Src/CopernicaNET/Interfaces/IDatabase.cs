using Arlanet.CopernicaNET.Models;
using Arlanet.CopernicaNET.Types;
using System;
using System.Collections.Generic;

namespace Arlanet.CopernicaNET.Interfaces
{
    internal interface IDatabase
    {
        int databaseId { get; set; }

        IEnumerable<Field> fields { get; set; }

        IEnumerable<CopernicaProfile<Object>> entities { get; set;}
    }
}
