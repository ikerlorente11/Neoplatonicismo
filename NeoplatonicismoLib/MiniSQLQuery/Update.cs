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
        private string[] m_value;
        private string m_valueComp;
        private string m_columnComp;
        public string Run(Database database)
        {
            string response = "";
            Table table = database.GetTables()[database.FindTable(m_table)];
            List<String> values = m_value.OfType<String>().ToList();

           for(int i=0; i<m_column.Length;i++)
            {
                table.UpdateRow(m_column[i], m_valueComp, m_operation, values);
            }
                


            

            return "Tuple(s) updated";
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

        public string[] Values()
        {
            return m_value;
        }

        public string valueComp()
        {
            return m_valueComp;
        }

        public string columnComp()
        {
            return m_columnComp;
        }

        public Update(String table, String[] column, String operation, String[] value, String valueComp)
        {
            m_table = table;
            m_column = column;
            m_operation = operation;
            m_value = value;
            m_valueComp = valueComp;

        }
    }
}
