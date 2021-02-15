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
        List<Table> tables= new List<Table>();

        public Database(String Name, String Username, String Password)
        {
            name = Name;
            username = Username;
            password = Password;
        }

        public void LoadDatabase()
        {

        }

        public List<Table> GetTables()
        {
            return tables;
        }

        public void CreateTable(String tableName, List<TableColumn> tableColumns )
        {
            Table table = new Table(tableName, tableColumns);
            tables.Add(table);
        }

        public void DropTable(String tableName)
        {
            Table table = FindTable(tableName);
            tables.Remove(table);
        }

        public void AlterTable(String tableName, String columnName, TableColumn column)
        {

        }

        public Table FindTable(String tableName)
        {
            foreach(Table table in tables)
            {
                if (table.GetName() == tableName)
                    return table;
            }
            return null;
        }

        public void SaveDatabase()
        {

        }
    }
}
