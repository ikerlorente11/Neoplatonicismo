using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace NeoplatonicismoLib.MiniSQLQuery
{
    public class Delete : IQuery
    {
        public string Run(Database database, object name)
        {
            string message = "Borrado con éxito";

            try
            {
                SqlCommand cmd = new SqlCommand("Delete from table where name = @name") ;
                
                    cmd.Parameters.Add("@name", SqlDbType.Text).Value = name;
                    cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                message = "No se ha podido borrar" ;
            }

            return message;
        }

        public string Run(Database satabase)
        {
            throw new NotImplementedException();
        }
    }
}
