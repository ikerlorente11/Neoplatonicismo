using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class Database
    {
        String name;
        String username;
        String password;
        List<Table> tables;

        public Database(String Name, String Username, String Password)
        {
            name = Name;
            username = Username;
            password = Password;
        }

        public void LoadDatabase()
        {

        }

        public void CreateTable(String tableName)
        {

        }

        public void DropTable(String tableName)
        {

        }

        public void AlterTable(String tableName, String columnName, TableColumn column)
        {

        }

        public List<List<String>> FindTable(String tableName)
        {
            return null;
        }

        public void SaveDatabase()
        {

        }
    }
}
