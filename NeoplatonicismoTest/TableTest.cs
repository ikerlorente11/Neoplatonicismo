using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class TableTest
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
            table.AddRow(new List<string> { "value3-1", "value3-2" });
            table.DeleteRow("Column1","value2-1","=");

            Assert.IsTrue(table.GetListRows().Count == 2);

            table.DeleteRow("Column1", "%lue%", "like");
            Assert.IsTrue(table.GetListRows().Count == 0);

            table.AddRow(new List<string> { "value1-1", "1" });
            table.AddRow(new List<string> { "value2-1", "2" });
            table.AddRow(new List<string> { "value3-1", "3" });

            table.DeleteRow("Column2", "1", "=");
            Assert.IsTrue(table.GetListRows().Count == 2);

            table.DeleteRow("Column2", "1", ">");
            Assert.IsTrue(table.GetListRows().Count == 0);
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
            table.UpdateRow("Column1", "value2-1", "=", new List<string> { "value3-1", "value3-2" });

            Assert.AreEqual(table.GetListRows()[1][0], "value3-1");
            Assert.AreEqual(table.GetListRows()[1][1], "value3-2");

            table.UpdateRow("Column1", "%lue%", "like", new List<string> { "value4-1", "value4-2" });
            Assert.AreEqual(table.GetListRows()[0][0], "value4-1");
            Assert.AreEqual(table.GetListRows()[0][1], "value4-2");
            Assert.AreEqual(table.GetListRows()[1][0], "value4-1");
            Assert.AreEqual(table.GetListRows()[1][1], "value4-2");
        }

        [TestMethod]
        public void FindRowTest()
        {
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("Column1", typeof(string)));
            tableColumns.Add(new TableColumn("Column2", typeof(int)));

            Table table = new Table("table", tableColumns);

            table.AddRow(new List<string> { "value1-1", "1" });
            table.AddRow(new List<string> { "value2-1", "3" });

            Assert.AreEqual(table.FindRow("Column1", "value2-1", "=")[0], 1);
            Assert.AreEqual(table.FindRow("Column1", "%lue2-1", "like")[0], 1);
            Assert.AreEqual(table.FindRow("Column1", "value2%", "like")[0], 1);
            Assert.AreEqual(table.FindRow("Column1", "%lue1%", "like")[0], 0);
            Assert.AreEqual(table.FindRow("Column1", "%lue%", "like")[0], 0);
            Assert.AreEqual(table.FindRow("Column1", "%lue%", "like")[1], 1);

            Assert.AreEqual(table.FindRow("Column2", "1", "=")[0], 0);
            Assert.AreEqual(table.FindRow("Column2", "1", ">=")[0], 0);
            Assert.AreEqual(table.FindRow("Column2", "3", "<=")[0], 0);
            Assert.AreEqual(table.FindRow("Column2", "3", "<=")[1], 1);
            Assert.AreEqual(table.FindRow("Column2", "1", ">")[0], 1);
            Assert.AreEqual(table.FindRow("Column2", "3", "<")[0], 0);

            Assert.AreEqual(table.FindRow("Column2", "hola", "=").Count, 0);
        }
    }
}
