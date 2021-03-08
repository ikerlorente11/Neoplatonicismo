using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Insert : IQuery
    {
        string tableName;
        string[] values;
        
        public string Run(Database database)
        {
            return "";
        }
    }
}
