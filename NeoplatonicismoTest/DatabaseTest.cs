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
            Database database = new Database("db", "admin", "admin");
            database.LoadDatabase();

            List<Table> tables = database.GetTables();
            Assert.AreEqual(tables[0].GetName(), "people");
            Assert.AreEqual(tables[1].GetName(), "cities");
            Assert.AreEqual(tables[2].GetName(), "temperature");

            Assert.AreEqual(tables[0].GetColumnsType()[0].GetName(), "nombre");
            Assert.AreEqual(tables[0].GetColumnsType()[0].GetTypeValue(), typeof(string));
            Assert.AreEqual(tables[0].GetColumnsType()[1].GetName(), "apellido");
            Assert.AreEqual(tables[0].GetColumnsType()[1].GetTypeValue(), typeof(string));
            Assert.AreEqual(tables[0].GetColumnsType()[2].GetName(), "edad");
            Assert.AreEqual(tables[0].GetColumnsType()[2].GetTypeValue(), typeof(Int32));
            Assert.AreEqual(tables[0].GetColumnsType()[3].GetName(), "email");
            Assert.AreEqual(tables[0].GetColumnsType()[3].GetTypeValue(), typeof(string));

            Assert.AreEqual(tables[0].GetListRows()[0][0], "Federico");
            Assert.AreEqual(tables[0].GetListRows()[0][1], "Fernandez");
            Assert.AreEqual(tables[0].GetListRows()[0][2], "25");
            Assert.AreEqual(tables[0].GetListRows()[0][3], "fede@gmail.com");
            Assert.AreEqual(tables[0].GetListRows()[1][0], "Aitor");
            Assert.AreEqual(tables[0].GetListRows()[1][1], "Perez");
            Assert.AreEqual(tables[0].GetListRows()[1][2], "43");
            Assert.AreEqual(tables[0].GetListRows()[1][3], "aitor@outlook.com");
            Assert.AreNotEqual(tables[0].GetListRows()[0][0], "Aitor");
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

        /*
        [TestMethod]
        public void AlterTableTest()
        {
            Database database = new Database("db", "admin", "admin");

            List<TableColumn> tableColumns = new List<TableColumn>();
            Table table = new Table("table", tableColumns);
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            TableColumn newTable = new TableColumn("ColumnA", typeof(string));

            database.CreateTable("table1", tableColumns);
            database.AlterTable("table1", "Column1", newTable);

            Assert.AreEqual(newTable, database.GetTables()[0].GetColumnsType()[0]);
        }
        */

        [TestMethod]
        public void FindTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table1", null);
            Assert.AreEqual(0, database.FindTable("table1"));
            Assert.AreEqual(-1, database.FindTable("table2"));
        }

        [TestMethod]
        public void SaveDatabaseTest()
        {

        }
    }
}