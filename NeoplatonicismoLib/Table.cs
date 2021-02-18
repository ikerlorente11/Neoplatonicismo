using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class Table
    {

        String name;
        List<TableColumn> columnsType;
        List<List<String>> rows = new List<List<string>>();

        public Table(String Name, List<TableColumn> ColumnsType)
        {
            name = Name;
            columnsType = ColumnsType;
        }

        public void AddRow(List<String> row)
        {
            rows.Add(row);
        }

        public void DeleteRow(String columnName, String value, String operador)
        {
            int position = FindRow(columnName,value,operador);
            if(position >= 0)
            {
                rows.RemoveAt(position);
            }
        }

        public void UpdateRow(String columnName, String value, String operador, List<String> row)
        {
            int position = FindRow(columnName, value, operador);
            if (position >= 0)
            {
                rows.Insert(position,row);
            }
        }

        public int FindRow(String columnName, String value, String operador)
        {
            int columnPos = -1;
            for(int i = 0; i < columnsType.Count && columnPos == -1; i++)
            {
                if (columnsType[i].GetName().Equals(columnName))
                {
                    columnPos = i;
                }
            }

            if(columnPos == -1)
            {
                return columnPos;
            }
            else
            {
                switch (operador)
                {
                    case "==":
                        for(int i = 0; i < rows.Count; i++)
                        {
                            if (rows[i][columnPos].Equals(value))
                            {
                                return i;
                            }
                        }
                        break;
                    case "<=":
                        for (int i = 0; i < rows.Count; i++)
                        {
                            if (rows[i][columnPos].CompareTo(value) <= 0)
                            {
                                return i;
                            }
                        }
                        break;
                    case ">=":
                        for (int i = 0; i < rows.Count; i++)
                        {
                            if (rows[i][columnPos].CompareTo(value) >= 0)
                            {
                                return i;
                            }
                        }
                        break;
                }
                return -2;
            }
        }

        public String GetName()
        {
            return name;
        }

        public List<TableColumn> GetColumnsType()
        {
            return columnsType;
        }

        public void SetColumnsType(List<TableColumn> ColumnsType)
        {
            columnsType = ColumnsType;
        }

        public List<List<String>> GetListRows()
        {
            return rows;
        }
    }
}
