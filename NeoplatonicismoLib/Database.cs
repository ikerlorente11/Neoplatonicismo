﻿using System;
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

        public List<Table> GetTables()
        {
            return null;
        }

        public void CreateTable(String tableName, List<TableColumn> tableColumns )
        {

        }

        public void DropTable(String tableName)
        {
            Table table = FindTable(tableName);
            tables.Remove(table);
        }

        public void AlterTable(String tableName, String columnName, TableColumn column)
        {

        }

        public List<Table> FindTable(String tableName)
        {
            return null;
        }

        public void SaveDatabase()
        {

        }
    }
}
