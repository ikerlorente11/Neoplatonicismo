using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    class Update : IQuery
    {
        private string m_table;
        private string[] m_column;
        private string m_operation;
        public string Run(Database database)
        {

            //const string UpdateAll = @"UPDATE ([a-zA-Z0-9]+) SET ([a-zA-Z0-9=_]+) WHERE ([a-zA-Z0-9=_]+);";
            return "";
        }

        public string Table()
        {
            return m_table;
        }

        public string[] Column()
        {
            return m_column;
        }

        public string Operation()
        {
            return m_operation;
        }

        public Update(String table, String[] column, String operation)
        {
            m_table = table;
            m_column = column;
            m_operation = operation;
        }
    }
}
