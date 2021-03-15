using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Create : IQuery
    {
        private String m_name;
        private List<TableColumn> m_tableColumns;

        public Create(String name, List<TableColumn> tableColumns)
        {
            m_name = name;
            m_tableColumns = tableColumns;
        }

        public string Table()
        {
            return m_name;
        }

        public List<TableColumn> TableColumns()
        {
            return m_tableColumns;
        }

        public string Run(Database database)
        {
            database.CreateTable(m_name, m_tableColumns);

            return "Table " + m_name + " created successfully";
        }
    }
}
