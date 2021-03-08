using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class SelectColumns : IQuery
    {
        private string m_table;
        private string[] m_columNames;
        private string m_columnName;
        private string m_columnValue;
        private char m_operation;

        public string Table()
        {
            return m_table;
        }

        public string[] ColumnNames()
        {
            return m_columNames;
        }

        public string ColumnName()
        {
            return m_columnName;
        }

        public string ColumnValue()
        {
            return m_columnValue;
        }

        public char Operation()
        {
            return m_operation;
        }

        public SelectColumns(String table, string[] columnNames, string columnName, string columnValue, char operation)
        {
            m_table = table;
            m_columNames = columnNames;
            m_columnName = columnName;
            m_columnValue = columnValue;
            m_operation = operation;
        }
        public string Run(Database database)
        {
            return "";
        }
    }
}
