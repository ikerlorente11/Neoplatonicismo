using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoplatonicismoLib;
using System.IO;

namespace NeoplatonicismoTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void LoadDatabaseTest()
        {
            String path = "db.txt";
            StreamWriter sw = File.CreateText(path);
            sw.AutoFlush = true;
            sw.Write("people[2]nombre[4]string[3]apellido[4]string[3]edad[4]int[3]email[4]string[2]Federico[3]Fernandez[3]25[3]fede@gmail.com[5]Aitor[3]Perez[3]43[3]aitor@outlook.com[1]cities[2]ciudad[4]string[3]cp[4]int[3]habitantes[4]int[3]pais[4]string[2]Vitoria[3]01000[3]250[3]España[5]Vigo[3]02000[3]190[3]España[1]temperature[2]pais[4]string[3]grados[4]double[3]cielo[4]string[2]alemania[3]-5.5[3]despejado[5]italia[3]18.2[3]nublado[5]canada[3]0.0[3]nublado");
            sw.AutoFlush = false;
            sw.Close();
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
        public void GetTablesTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.CreateTable("table1", null);
            database.CreateTable("table2", null);
            database.CreateTable("table3", null);
            Assert.AreEqual(3, database.GetTables().Count);
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
        public void AddToTableTest()
        {
            Database database = new Database("db", "admin", "admin");
            Type type = typeof(string);
            List<TableColumn> tableColumns = new List<TableColumn>();
            tableColumns.Add(new TableColumn("name", type));
            database.CreateTable("table", tableColumns);
            List<string> row = new List<string>();
           
            database.AddToTable("table", row);
            Table table = database.GetTables()[0];
            Assert.IsNotNull(table.FindRow("name", "table", "like"));
        }

        [TestMethod]
        public void SaveDatabaseTest()
        {
            Database database = new Database("db", "admin", "admin");
            database.LoadDatabase();
            database.SaveDatabase();

            String db = File.ReadAllText("db.txt");
            String db2 = File.ReadAllText("db.txt");

            Assert.AreEqual(db, db2);
        }

        [TestMethod]
        public void ExecuteMiniSqlQueryTest()
        {
            String path = "db.txt";
            StreamWriter sw = File.CreateText(path);
            sw.AutoFlush = true;
            sw.Write("people[2]nombre[4]string[3]apellido[4]string[3]edad[4]int[3]email[4]string[2]Federico[3]Fernandez[3]25[3]fede@gmail.com[5]Aitor[3]Perez[3]43[3]aitor@outlook.com[1]cities[2]ciudad[4]string[3]cp[4]int[3]habitantes[4]int[3]pais[4]string[2]Vitoria[3]01000[3]250[3]España[5]Vigo[3]02000[3]190[3]España[1]temperature[2]pais[4]string[3]grados[4]double[3]cielo[4]string[2]alemania[3]-5.5[3]despejado[5]italia[3]18.2[3]nublado[5]canada[3]0.0[3]nublado");
            sw.AutoFlush = false;
            sw.Close();
            Database database = new Database("db", "admin", "admin");
            database.LoadDatabase();

            string response = database.ExecuteMiniSqlQuery("SELECT nombre,apellido FROM people;");
            Assert.AreEqual(response, "['nombre','apellido']{'Federico','Fernandez'}{'Aitor','Perez'}");

            response = database.ExecuteMiniSqlQuery("SELECT nombre,apellido,edad FROM people WHERE nombre = Aitor;");
            Assert.AreEqual(response, "['nombre','apellido','edad']{'Aitor','Perez','43'}");

            response = database.ExecuteMiniSqlQuery("SELECT * FROM people;");
            Assert.AreEqual(response, "['nombre','apellido','edad','email']{'Federico','Fernandez','25','fede@gmail.com'}{'Aitor','Perez','43','aitor@outlook.com'}");
            
            response = database.ExecuteMiniSqlQuery("SELECT * FROM people WHERE nombre = Aitor;");
            Assert.AreEqual(response, "['nombre','apellido','edad','email']{'Aitor','Perez','43','aitor@outlook.com'}");

            int nTablasOld = database.GetTables().Count;
            response = database.ExecuteMiniSqlQuery("CREATE TABLE house (direction string,number int);");
            Assert.AreEqual(response, "Table house created successfully");
            Assert.IsTrue(database.GetTables().Count == (nTablasOld + 1));
        }
    }
}