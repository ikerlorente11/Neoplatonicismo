using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class SelectAll : IQuery
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
        public string Operation()
        {
            return m_operation;

        }
        public string Value()
        {
            return m_value;

        }
        public SelectAll(String table, String column, String operation, String value)
        {
            m_table = table;
            m_column = column;
            m_operation = operation;
            m_value = value;
        }

        public string Run(Database database)
        {
           
            return "";
        }
    }
}
