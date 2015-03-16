using Arlanet.CopernicaNET.Data;
using Arlanet.CopernicaNET.Tests.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arlanet.CopernicaNET.Tests
{
    [TestClass]
    public class Copernica
    {
        [TestMethod]
        public void CreateProfile_SimpleValues_InsertSuccess()
        {
            var person = new Person { Email = "support@arlanet.com", Name = "Arlanet", ID = 14 };
            CopernicaHandler.Instance.Add(person);
        }

        [TestMethod]
        [ExpectedException(typeof(CopernicaException),"The specified identifier is empty.")]
        public void CreateProfile_IdIsEmpty_ExceptionThrown()
        {
            var person = new Person { Email = "support@arlanet.com", Name = "Arlanet" };
            CopernicaHandler.Instance.Add(person);
        }

        [TestMethod]
        public void DeleteProfile_CorrectValues_DeleteSuccess()
        {
            var person = new Person { Email = "support@arlanet.com", Name = "Arlanet", ID = 14 };
            CopernicaHandler.Instance.Delete(person);
        }

        [TestMethod]
        [ExpectedException(typeof(CopernicaException), "The specified identifier is empty.")]
        public void DeleteProfile_IdIsEmpty_ExceptionThrown()
        {
            var person = new Person { Email = "support@arlanet.com", Name = "Arlanet" };
            CopernicaHandler.Instance.Delete(person);
        }

        [TestMethod]
        [ExpectedException(typeof (CopernicaException), "The profile was not found.")]
        public void DeleteProfile_ProfileNotFound_ExceptionThrown()
        {
            var person = new Person { Email = "support@arlanet.com", Name = "Arlanet", ID = 15 };
            CopernicaHandler.Instance.Delete(person);
        }

        [TestMethod]
        [ExpectedException(typeof (CopernicaException), "Database attribute is expected.")]
        public void ValidateAttributes_NoDatabaseId_ExceptionThrown()
        {
            CopernicaHandler_NoDatabaseId.Instance.Add(new Person_NoDatabaseId());
        }
    }
}
