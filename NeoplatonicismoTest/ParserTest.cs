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
            IQuery query = Parser.Parse("SELECT * FROM people WHERE edad = -10.78;");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("people", (query as SelectAll).Table());
            Assert.AreEqual("edad", (query as SelectAll).Column());
            Assert.AreEqual("=", (query as SelectAll).Operation());
            Assert.AreEqual("-10.78", (query as SelectAll).Value());

            query = Parser.Parse("SELECT nombre FROM people WHERE nombre = pepe;");
            Assert.IsTrue(query is SelectColumns);
            Assert.AreEqual("people", (query as SelectColumns).Table());
            Assert.AreEqual("nombre", (query as SelectColumns).ColumnNames()[0]);
            Assert.AreEqual("nombre", (query as SelectColumns).ColumnName());
            Assert.AreEqual("pepe", (query as SelectColumns).ColumnValue());
            Assert.AreEqual('=', (query as SelectColumns).Operation());
        }
    }
}
