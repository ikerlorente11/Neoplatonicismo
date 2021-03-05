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

        public string Table()
        {
            return m_table;
        }

        public string[] ColumnNames()
        {
            return m_columNames;
        }

        public SelectColumns(String table, string[] columnNames)
        {
            m_table = table;
            m_columNames = columnNames;
        }
        public string Run(Database database)
        {
            return "";
        }
    }
}
