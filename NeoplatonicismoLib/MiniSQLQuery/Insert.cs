using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Insert : IQuery
    {
        private string m_tableName;
        private string[] m_values;
        
        public string TableName()
        {
            return m_tableName;
        }

        public string[] Values()
        {
            return m_values;
        }


        public Insert(string tableName, string[] values)
        {
            m_tableName = tableName;
            m_values = values;
        }
        
        public string Run(Database database)
        {
            return "";
        }
    }
}
