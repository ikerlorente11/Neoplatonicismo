using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public static class Parser
    {
        public static IQuery Parse(string miniSqlSencence)
        {
            const string dropPattern = @"DROP TABLE ([a-zA-Z0-9]+)";
            const string create = @"CREATE TABLE ([A-za-z0-9]+) (\(((([A-za-z0-9]+) ((string|int|double),?))+)\))";
            const string insert = @"INSERT INTO ([A-za-z0-9]+) VALUES \(([A-za-z0-9]+,?)+\)";
            const string update = @"UPDATE ([a-zA-Z0-9]+) SET ([a-zA-Z0-9_.]+[=][a-zA-Z0-9_.]+,?)+ WHERE ([a-zA-Z0-9_.]+[<->-=][a-zA-Z0-9_.]+)";
            const string delete = @"DELETE FROM ([A-Za-z0-9]+) WHERE ([A-Za-z0-9]+) ([<->-=]) ([A-Za-z0-9].+)";
            const string selectAllParameter = @"SELECT \* FROM ([a-zA-Z0-9]+)( WHERE ([a-zA-Z0-9]+) ([<=>]) ([a-zA-Z0-9.-]+))?";
            const string selectColumnsPattern = @"SELECT ([a-zA-Z0-9,]+) FROM ([a-zA-Z0-9]+)( WHERE ([a-zA-Z0-9,]+) ([<>=]) ([a-zA-Z0-9,]+))?";


            Match match = Regex.Match(miniSqlSencence, selectAllParameter);
            if (match.Success)
            {
                if (match.Groups[3].Value == "")
                {
                    SelectAll selectAll = new SelectAll(match.Groups[1].Value, null, null, null);
                    return selectAll;
                }
                else
                {
                    SelectAll selectAll = new SelectAll(match.Groups[1].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value);
                    return selectAll;
                }

            }

            match = Regex.Match(miniSqlSencence, create);
            if (match.Success)
            {
                string name = match.Groups[1].Value;
                string[] columns = match.Groups[3].Value.Split(',');
                List<TableColumn> tableColumns = new List<TableColumn>();

                foreach (string column in columns)
                {
                    switch (column.Split(' ')[1])
                    {
                        case "string":
                            tableColumns.Add(new TableColumn(column.Split(' ')[0], typeof(string)));
                            break;
                        case "int":
                            tableColumns.Add(new TableColumn(column.Split(' ')[0], typeof(int)));
                            break;
                        case "double":
                            tableColumns.Add(new TableColumn(column.Split(' ')[0], typeof(double)));
                            break;
                    }
                }

                return new Create(name, tableColumns);
            }

            match = Regex.Match(miniSqlSencence, dropPattern);
            if (match.Success)
            {

                Drop drop = new Drop(match.Groups[1].Value);
                return drop;

            }

            match = Regex.Match(miniSqlSencence, selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');

                if (match.Groups[4].Value == "")
                {
                    return new SelectColumns(match.Groups[2].Value, columnNames, null, null, ' ');
                }
                else
                {
                    return new SelectColumns(match.Groups[2].Value, columnNames, match.Groups[4].Value, match.Groups[6].Value, match.Groups[5].Value.ToCharArray()[0]);
                }
            }

            match = Regex.Match(miniSqlSencence, update);
            if (match.Success)
            {
                string[] columnValue = match.Groups[2].Value.Split(',');
                if (match.Groups[3].Value == "")
                {
                    return new Update(match.Groups[1].Value, columnValue, null);
                }
                else
                {
                    return new Update(match.Groups[1].Value, columnValue, match.Groups[3].Value);
                }
            }

            match = Regex.Match(miniSqlSencence, delete);
            if (match.Success)
            {
                if (match.Groups[3].Value == "")
                {
                    Delete delete1 = new Delete(match.Groups[1].Value, null, null, null);
                    return delete1;
                }
                else
                {
                    return new Delete(match.Groups[1].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value);
                }
            }
            

            match = Regex.Match(miniSqlSencence, insert);
            if (match.Success)
            {
                string[] insertions = match.Groups[2].Value.Split(',');
                return new Insert(match.Groups[1].Value, insertions);
            }

            return null;
        }
    }
}
