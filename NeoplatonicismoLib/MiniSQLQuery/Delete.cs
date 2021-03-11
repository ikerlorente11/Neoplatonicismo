using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Delete : IQuery
    {
        public string Run(Database database, object name)
        {
            string message = "Borrado con éxito";

            try
            {
                SqlCommand cmd = new SqlCommand("Delete from table where name = @name") ;
                
                    cmd.Parameters.Add("@name", SqlDbType.Text).Value = name;
                    cmd.ExecuteNonQuery();
                

        }
        public string Operation()
        {
            return m_operation;

        }
        public string Value()
        {
            return m_value;

        }

        public Delete (String table, String column, String operation, String value)
        {
            m_table = table;
            m_column = column;
            m_operation = operation;
            m_value = value;
        }
           
    }

        public string Run (Database satabase)
        {
            throw new NotImplementedException();
        }
    }
}
