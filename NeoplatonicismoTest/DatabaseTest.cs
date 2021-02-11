using System;
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

        }

        [TestMethod]
        public void DropTableTest()
        {
            Database database = new Database("DB", "admin", "admin");
            database.CreateTable("table1");

            database.DropTable("table1");

            Assert.AreEqual(0, database.GetTable().Count());

        }

        [TestMethod]
        public void AlterTable()
        {

        }

        [TestMethod]
        public void FindTableTest()
        {

        }

        [TestMethod]
        public void SaveDatabaseTest()
        {

        }
    }
}
