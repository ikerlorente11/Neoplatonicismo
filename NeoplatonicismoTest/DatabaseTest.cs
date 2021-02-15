using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void LoadDatabaseTest()
        {

        }

        [TestMethod]
        public void CreateTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table", null);
            Assert.AreEqual(1, database.GetTables().Count());

        }

        [TestMethod]
        public void DropTableTest()
        {
            Database database = new Database("DB", "admin", "admin");
            database.CreateTable("table1", null);

            database.DropTable("table1");

            Assert.AreEqual(0, database.GetTables().Count);

        }

        [TestMethod]
        public void AlterTable()
        {
            Database database = new Database("db", "admin", "admin");

            List<TableColumn> tableColumns = new List<TableColumn>();
            Table table = new Table("table", tableColumns);
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            TableColumn newTable = new TableColumn("ColumnA", typeof(String));

            database.CreateTable("table1", tableColumns);
            database.AlterTable("table1", "Column1", newTable);

            Assert.AreEqual(newTable, database.GetTables()[0].GetColumnsType()[0]);
        }

        [TestMethod]
        public void FindTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table1", null);
            Table table = database.FindTable("table1");
            Assert.AreEqual("table1", table.GetName());
           
        }

        [TestMethod]
        public void SaveDatabaseTest()
        {

        }
    }
}
