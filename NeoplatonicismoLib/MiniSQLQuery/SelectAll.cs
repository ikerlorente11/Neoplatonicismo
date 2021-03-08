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

        public string Table()
        {
            return m_table;
        }
        public SelectAll(String table)
        {
            m_table = table;
        }

        public string Run(Database database)
        {
            return "";
        }
    }
}
