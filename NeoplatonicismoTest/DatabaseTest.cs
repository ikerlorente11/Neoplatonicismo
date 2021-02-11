using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    class DatabaseTest
    {
        [TestMethod]
        public void LoadDatabaseTest()
        {

        }

        [TestMethod]
        public void CreateTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table");
            Assert.AreEqual(1, database.GetTables().Count());

        }

        [TestMethod]
        public void DropTableTest()
        {

        }

        [TestMethod]
        public void AlterTable()
        {

        }

        [TestMethod]
        public void FindTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table1");
            List<List<String>> tables = database.FindTable("table1");
            Assert.AreEqual(tables.GetName() == "table1");
        }

        [TestMethod]
        public void SaveDatabaseTest()
        {

        }
    }
}
