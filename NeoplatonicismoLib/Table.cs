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
        List<List<String>> rows;

        public Table(String name, List<TableColumn> ColumnsType)
        {
            columnsType = ColumnsType;
        }

        public void AddRow(List<String> row)
        {

        }

        public void DeleteRow(String columnName, String value)
        {

        }

        public void Update(String columnName, String value, List<String> row)
        {

        }

        public void Find(String columnName, String value)
        {

        }
    }
}
