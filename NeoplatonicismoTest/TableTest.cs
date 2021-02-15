using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    class TableTest
    {
        [TestMethod]
        public void AddRowTest()
        {
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            tableColumns.Add(new TableColumn("Column2", typeof(int)));

            Table table = new Table("table", tableColumns);

            table.AddRow(new List<string> {"value1-1","value1-2"});
            Assert.IsTrue(table.GetListRows().Count == 1);
            table.AddRow(new List<string> { "value2-1", "value2-2" });
            Assert.IsTrue(table.GetListRows().Count == 2);
        }

        [TestMethod]
        public void DeleteRowTest()
        {
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            tableColumns.Add(new TableColumn("Column2", typeof(int)));

            Table table = new Table("table", tableColumns);

            table.AddRow(new List<string> { "value1-1", "value1-2" });
            table.AddRow(new List<string> { "value2-1", "value2-2" });
            table.DeleteRow("column1","value2-1","=");

            Assert.IsTrue(table.GetListRows().Count == 1);
        }

        [TestMethod]
        public void UpdateRowTest()
        {
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            tableColumns.Add(new TableColumn("Column2", typeof(int)));

            Table table = new Table("table", tableColumns);

            table.AddRow(new List<string> { "value1-1", "value1-2" });
            table.AddRow(new List<string> { "value2-1", "value2-2" });
            table.UpdateRow("column1", "value2-1", "=", new List<string> { "value3-1", "value3-2" });

            Assert.AreEqual(table.GetListRows()[1], new List<string> { "value3-1", "value3-2" });
        }

        [TestMethod]
        public void FindRowTest()
        {
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            tableColumns.Add(new TableColumn("Column2", typeof(int)));

            Table table = new Table("table", tableColumns);

            table.AddRow(new List<string> { "value1-1", "value1-2" });
            table.AddRow(new List<string> { "value2-1", "value2-2" });

            Assert.AreEqual(table.FindRow("column1", "value2-1", "="), new List<string> { "value2-1", "value2-2" });
        }
    }
}
