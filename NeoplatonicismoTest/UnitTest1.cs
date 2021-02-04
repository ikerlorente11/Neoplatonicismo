using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
        }

        [TestMethod]
        public void FindByNameTest()
        {
        }

        [TestMethod]
        public void FindByEmailTest()
        {
            Contact contact1 = new contact("Imanol", "698745213", "imanolal@gmail.com");
            Contact contact2 = new contact("Andres", "654789312", "andres10mt@gmail.com");
            contacts.add(contact1);
            contacts.add(contact2);
            contacts.find
            Assert.AreEquals

        }

        [TestMethod]
        public void ToStringTest()
        {
            for (int = 0; i < contacts.length; int++)¨{

                Console.WriteLine($"Initial list: {contacts.AsString()}");
                Console.WriteLine();
            }
        }
    }
}
