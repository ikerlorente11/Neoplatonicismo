using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;
using NeoplatonicismoLib.MiniSQLQuery;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Parsing()
        {
            IQuery query = Parser.Parse("SELECT * FROM people;");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("people", (query as SelectAll).Table());
        }
    }
}
