using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Drop : IQuery
    {
        private string m_table;
        public Drop(String table)
        {
            m_table = table;
        }
        public string Table()
        {
            return m_table;

        }
        public string Run(Database database)
        {
            database.DropTable(m_table);
            return "Table " + m_table + " deleted";
        }
    }
}
