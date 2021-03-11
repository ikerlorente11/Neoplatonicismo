using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.SqlServer;
//using System.Data.Sql;
//using System.Data.SqlClient;
//using System.Data;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Delete : IQuery
    {
        private string m_table;
        private string m_column;
        private string m_operation;
        private string m_value;

        public string Table()
        {
            return m_table;

        }
        public string Column()
        {
            return m_column;

        }

        public Delete (String table, String column)
        {
            m_table = table;
            m_column = column;
            
        }
           
    }

        public string Run(Database satabase)
        {
            return "";
        }
}

