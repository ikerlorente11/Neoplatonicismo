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
            string response = "";
            Table table = database.GetTables()[database.FindTable(m_table)];

            List<TableColumn> columnsType = table.GetColumnsType();
            List<int> columnPos = new List<int>();
            for(int i = 0; i < m_columNames.Length; i++)
            {
                for(int j = 0; j < columnsType.Count; j++)
                {
                    if (m_columNames[i].Equals(columnsType[j].GetName()))
                    {
                        columnPos.Add(j);
                    }
                }
            }

            List<List<string>> rows = new List<List<string>>();

            if (m_columnName == null && m_columnValue == null && m_operation == ' ')
            {
                rows = table.GetListRows();
            }
            else
            {
                List<int> rowsPos = table.FindRow(m_columnName, m_columnValue, m_operation.ToString());
                foreach (int pos in rowsPos)
                {
                    rows.Add(table.GetListRows()[pos]);
                }
            }

            response += "[";
            for(int i = 0; i < m_columNames.Length; i++)
            {
                if(i < m_columNames.Length - 1)
                {
                    response += "'" + m_columNames[i] + "',";
                }
                else
                {
                    response += "'" + m_columNames[i] + "'";
                }
            }
            response += "]";

            for(int i = 0; i < rows.Count; i++)
            {
                response += "{";
                for(int j = 0; j < columnPos.Count; j++)
                {
                    if (j == columnPos.Count - 1)
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
