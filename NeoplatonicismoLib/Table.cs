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

        }

        public void UpdateRow(String columnName, String value, String operador, List<String> row)
        {

        }

        public List<String> FindRow(String columnName, String value, String operador)
        {
            return null;
        }

        public String GetName()
        {
            return name;
        }

        public List<TableColumn> GetColumnType()
        {
            return columnsType;
        }

        public void SetColumnType()
        {

        }

        public List<List<String>> GetListRows()
        {
            return rows;
        }
    }
}
