using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeoplatonicismoLib
{
    public class Database
    {
        String name;
        String username;
        String password;
        List<Table> tables = new List<Table>();

        public Database(String Name, String Username, String Password)
        {
            name = Name;
            username = Username;
            password = Password;
        }

        public void LoadDatabase()
        {
            String path = "../../../structureTest1.txt";
            String db = File.ReadAllText(path);

            string[] tables = db.Split(new string[] { "[1]" }, StringSplitOptions.None);

            foreach (String table in tables)
            {
                string tableName = table.Split(new string[] { "[2]" }, StringSplitOptions.None)[0];
                string[] tableColumnTypes = table.Split(new string[] { "[2]" }, StringSplitOptions.None)[1].Split(new string[] { "[3]" }, StringSplitOptions.None);
                List<TableColumn> tableColumns = new List<TableColumn>();

                foreach (string columnType in tableColumnTypes)
                {
                    switch (columnType.Split(new string[] { "[4]" }, StringSplitOptions.None)[1])
                    {
                        case "string":
                            tableColumns.Add(new TableColumn(columnType.Split(new string[] { "[4]" }, StringSplitOptions.None)[0], typeof(string)));
                            break;
                        case "int":
                            tableColumns.Add(new TableColumn(columnType.Split(new string[] { "[4]" }, StringSplitOptions.None)[0], typeof(int)));
                            break;
                        case "double":
                            tableColumns.Add(new TableColumn(columnType.Split(new string[] { "[4]" }, StringSplitOptions.None)[0], typeof(double)));
                            break;
                    }
                }

                CreateTable(tableName, tableColumns);

                string[] tableRows = table.Split(new string[] { "[2]" }, StringSplitOptions.None)[2].Split(new string[] { "[5]" }, StringSplitOptions.None);
                foreach (string tableRow in tableRows)
                {
                    string[] values = tableRow.Split(new string[] { "[3]" }, StringSplitOptions.None);
                    AddToTable(tableName, values.ToList());
                }
            }
        }

        public List<Table> GetTables()
        {
            return tables;
        }

        public void CreateTable(String tableName, List<TableColumn> tableColumns)
        {
            Table table = new Table(tableName, tableColumns);
            tables.Add(table);
        }

        public void DropTable(String tableName)
        {
            tables.RemoveAt(FindTable(tableName));
        }

        /*
        public void AlterTable(String tableName, String columnName, TableColumn column)
        {
            Table table = FindTable(tableName);
            List<TableColumn> lista = table.GetColumnsType();
            for(int i=0; i<lista.Count; i++)
            {
                if(lista[i].GetName() == columnName )
                {
                    table.SetColumnsType(lista);
                    lista.Insert(i, column);
                }
            }
           
        }
        */

        public int FindTable(String tableName)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].GetName() == tableName)
                    return i;
            }
            return -1;
        }

        public void AddToTable(String tableName, List<string> row)
        {
            tables[FindTable(tableName)].AddRow(row);
        }

        public void SaveDatabase()
        {

        }
    }
}
