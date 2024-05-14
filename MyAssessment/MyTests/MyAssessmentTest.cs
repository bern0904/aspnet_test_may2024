using MyAssessment.MapperProfiles;
using System.Net.Sockets;
using MyAssessment.Domain;

namespace MyTests
{
    public class MyAssessmentTest
    {
        [TestCase]

        public void ProgrammerAssessment()
        {

            var address = new Address("123 Apache Trail", "Queen Creek", "MD", "21224");

            var person = new Person("Jane", "Smith", address);

            var biz = new Business("Maztec ", address);

            Assert.IsNull(person.Id);

            person.Save();

            Assert.IsNotNull(person.Id);

            Assert.IsNull(biz.Id);

            biz.Save();

            Assert.IsNotNull(biz.Id);

            Person savedPerson = Person.Find(person.Id);

            Assert.IsNotNull(savedPerson);

            Assert.AreSame(person.Address, address);

            Assert.AreEqual(savedPerson.Address, address);

            Assert.AreEqual(person.Id, savedPerson.Id);

            Assert.AreEqual(person.FirstName, savedPerson.FirstName);

            Assert.AreEqual(person.LastName, savedPerson.LastName);

            Assert.AreNotEqual(person, savedPerson);

            Assert.AreNotSame(person, savedPerson);

            Assert.AreNotSame(person.Address, savedPerson.Address);

            Assert.AreEqual(person.Address, savedPerson.Address);

            Business savedBusiness = Business.Find(biz.Id);

            Assert.IsNotNull(savedBusiness);

            Assert.AreSame(biz.Address, address);

            Assert.AreEqual(savedBusiness.Address, address);

            Assert.AreEqual(biz.Id, savedBusiness.Id);

            Assert.AreEqual(biz.Name, savedBusiness.Name);

            Assert.AreNotEqual(biz, savedBusiness);

            Assert.AreNotSame(biz, savedBusiness);

            Assert.AreNotSame(biz.Address, savedBusiness.Address);

            Assert.AreEqual(biz.Address, savedBusiness.Address);

            var deletedPersonId = person.Id;

            person.Delete();

            Assert.IsNull(person.Id);

            Assert.IsNull(Person.Find(deletedPersonId));

            var deletedBizId = biz.Id;

            biz.Delete();

            Assert.IsNull(biz.Id);

            Assert.IsNull(Business.Find(deletedBizId));
        }
    }
}