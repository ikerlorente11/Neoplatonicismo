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
           if( CheckTypes(row)==true)
           {
                rows.Add(row);
           }
            
           
        }

        public void DeleteRow(String columnName, String value, String operador)
        {
            List<int> positions = FindRow(columnName, value, operador);
            positions.Reverse();
            foreach (int position in positions)
            {
                if (position >= 0)
                {
                    rows.RemoveAt(position);
                }
            }
        }

        public void UpdateRow(String columnName, String value, String operador, List<String> row)
        {
            
            foreach(int position in FindRow(columnName, value, operador))
            {
                if (position >= 0 && CheckTypes(row)==true)
                {
                    
                    rows.Insert(position, row);
                }
            }
        }

        public List<int> FindRow(String columnName, String value, String operador)
        {
            int columnPos = -1;
            List<int> positions = new List<int>();

            for(int i = 0; i < columnsType.Count && columnPos == -1; i++)
            {
                if (columnsType[i].GetName().Equals(columnName))
                {
                    columnPos = i;
                }
            }

            if(columnPos == -1)
            {
                return positions;
            }
            else
            {
                Type tipo = columnsType[columnPos].GetType();
                if (columnsType[columnPos].GetTypeValue() == typeof(String))
                {
                    switch (operador)
                    {
                        case "=":
                            for (int i = 0; i < rows.Count; i++)
                            {
                                if (rows[i][columnPos].Equals(value))
                                {
                                    positions.Add(i);
                                }
                            }
                            break;
                        case "like":
                            if(value[0] == '%' && value[value.Length - 1] == '%')
                            {
                                String val = value.Substring(1, value.Length - 2);
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (rows[i][columnPos].Contains(val))
                                    {
                                        positions.Add(i);
                                    }
                                }
                            }
                            else if (value[0] == '%')
                            {
                                String val = value.Substring(1, value.Length - 1);
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (rows[i][columnPos].EndsWith(val))
                                    {
                                        positions.Add(i);
                                    }
                                }
                            }
                            else if (value[value.Length - 1] == '%')
                            {
                                String val = value.Substring(0, value.Length - 1);
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (rows[i][columnPos].StartsWith(val))
                                    {
                                        positions.Add(i);
                                    }
                                }
                            }
                            break;
                    }
                }
                else if(columnsType[columnPos].GetTypeValue() == typeof(int) || columnsType[columnPos].GetTypeValue() == typeof(double))
                {
                    try
                    {
                        Double decim = Convert.ToDouble(value);

                        switch (operador)
                        {
                            case "=":
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (Convert.ToDouble(rows[i][columnPos]) == decim)
                                    {
                                        positions.Add(i);
                                    }
                                }
                                break;
                            case "<=":
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (Convert.ToDouble(rows[i][columnPos]) <= decim)
                                    {
                                        positions.Add(i);
                                    }
                                }
                                break;
                            case ">=":
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (Convert.ToDouble(rows[i][columnPos]) >= decim)
                                    {
                                        positions.Add(i);
                                    }
                                }
                                break;
                            case "<":
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (Convert.ToDouble(rows[i][columnPos]) < decim)
                                    {
                                        positions.Add(i);
                                    }
                                }
                                break;
                            case ">":
                                for (int i = 0; i < rows.Count; i++)
                                {
                                    if (Convert.ToDouble(rows[i][columnPos]) > decim)
                                    {
                                        positions.Add(i);
                                    }
                                }
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        return positions;
                    }
                }
                
                return positions;
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

        public Boolean CheckTypes(List<String> row)
        {
            Boolean validity = true;
            for (int i = 0; i < columnsType.Count && validity != false; i++)
            {
                if (columnsType[i].GetTypeValue() == typeof(int))
                {
                    try
                    {
                        Convert.ToInt32(row[i]);
                    }
                    catch (FormatException)
                    {

                        validity = false;
                    }
                }
                else if (columnsType[i].GetTypeValue() == typeof(double))
                {
                    try
                    {
                        Convert.ToDouble(row[i]);
                    }
                    catch (FormatException)
                    {
                        validity = false;
                    }

                }
                    
            }
            return validity;
        }
    }
}
