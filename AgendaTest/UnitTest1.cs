using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace AgendaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            Contact contact1 = new Contact("Pepe");
            Contact contact2 = new Contact("Felipe");
            ContactList contactList = new ContactList();
            contactList.add(contact1);
            contactList.add(contact2);
            Assert.AreEqual(contactList.count(),2);
        }

        [TestMethod]
        public void FindByNameTest()
        {
            Contact contact1 = new Contact("Pepe");
            ContactList contactList = new ContactList();
            contactList.add(contact1);
            Contact contact2 = contactList.findByName("Pepe");
            Contact contact3 = contactList.findByName("pepe");
            Contact contact4 = contactList.findByName("Julio");
            Assert.IsNotNull(contact2);
            Assert.IsNotNull(contact3);
            Assert.IsNull(contact4);
        }

        [TestMethod]
        public void FindByEmailTest()
        {
            Contact contact1 = new Contact("Pepe","111111111","pepe@gmail.com");
            Contact contact2 = new Contact("Felipe", "555555555", "felipe@gmail.com");
            ContactList contactList = new ContactList();
            contactList.add(contact1);
            contactList.add(contact2);
            Contact contact3 = contactList.findByEmail("pepe@gmail.com");
            Contact contact4 = contactList.findByEmail("felip3@gmail.com");
            Assert.IsNotNull(contact3);
            Assert.IsNull(contact4);

        }
        

        [TestMethod]
        public void ToStringTest()
        {
            Contact contact1 = new Contact("Pepe", "111111111", "pepe@gmail.com");
            ContactList contactList = new ContactList();
            Assert.IsTrue(contact1.ToString()=="Pepe,111111111,pepe@gmail.com");
          

        }
    }
}
