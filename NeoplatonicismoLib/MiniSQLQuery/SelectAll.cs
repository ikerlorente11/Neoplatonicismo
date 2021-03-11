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
            string response = "";
            Table table = database.GetTables()[database.FindTable(m_table)];

            List<TableColumn> columnsType = table.GetColumnsType();

            List<List<string>> rows = new List<List<string>>();

            if (m_column == null && m_value == null && m_operation == null)
            {
                rows = table.GetListRows();
            }
            else
            {
                List<int> rowsPos = table.FindRow(m_column, m_value, m_operation);
                foreach (int pos in rowsPos)
                {
                    rows.Add(table.GetListRows()[pos]);
                }
            }



            response += "[";
            for (int i = 0; i < columnsType.Count; i++)
            {
                if (i < columnsType.Count - 1)
                {
                    response += "'" + columnsType[i].GetName() + "',";
                }
                else
                {
                    response += "'" + columnsType[i].GetName() + "'";
                }
            }
            response += "]";

            for (int i = 0; i < rows.Count; i++)
            {
                response += "{";
                for (int j = 0; j < rows[i].Count; j++)
                {
                    if (j == rows[i].Count - 1)
                    {
                        response += "'" + rows[i][j] + "'";
                    }
                    else
                    {
                        response += "'" + rows[i][j] + "',";
                    }
                }
                response += "}";
            }

            return response;
        }
    }
}
    

