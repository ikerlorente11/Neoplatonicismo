using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class TableColumnTest
    {
        [TestMethod]
        public void GetNameTest()
        {
            TableColumn nameColumn = new TableColumn("Name", typeof(String));
            Assert.IsNotNull(nameColumn.GetName());
            Assert.IsTrue(nameColumn.GetName() == "Name");
            Assert.IsFalse(nameColumn.GetName() == "Id");
        }
        [TestMethod]
        public void GetTypeValueTest()
        {
            TableColumn nameColumn = new TableColumn("Name", typeof(String));
            Assert.IsNotNull(nameColumn.GetType());
            Assert.IsTrue(nameColumn.GetType() == typeof(String));
            Assert.IsFalse(nameColumn.GetType() == typeof(int));
        }

    }
}
