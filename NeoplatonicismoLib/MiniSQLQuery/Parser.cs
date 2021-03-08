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
            const string selectAllParameter = @"SELECT \* FROM ([a-zA-Z0-9]+)";
            const string selectColumnsPattern = @"SELECT ([a-zA-Z0-9,]+) FROM ([a-zA-Z0-9]+)( WHERE ([a-zA-Z0-9,]+) ([<>=]) ([a-zA-Z0-9,]+))?";

            Match match = Regex.Match(miniSqlSencence, selectAllParameter);
            if (match.Success)
            {
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }

            match = Regex.Match(miniSqlSencence, selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');
                SelectColumns selectColumns = new SelectColumns(match.Groups[2].Value, columnNames, match.Groups[4].Value, match.Groups[6].Value, match.Groups[5].Value.ToCharArray()[0]);
                return selectColumns;
            }


            return null;
        }
    }
}
