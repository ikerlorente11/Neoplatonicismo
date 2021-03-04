using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class Controller
    {
        Database db;

        public Controller()
        {
        }

        public void connect(String dbName, String user, String password)
        {
            db = new Database(dbName, user, password);
            db.LoadDatabase();
        }

        public List<List<string>> executeQuery(String query)
        {
            return select(query);
        }

        public string executeUpdate(String query)
        {
            switch (query.Split(' ')[0].ToLower())
            {
                case "create":
                    return create(query);
                case "drop":
                    return drop(query);
                case "insert":
                    return insert(query);
                case "update":
                    return update(query);
                case "delete":
                    return delete(query);
                default:
                    return "Error";
            }
        }

        private string create(String query)
        {
            return "";
        }

        private string drop(String query)
        {
            return "";
        }

        private List<List<string>> select(String query)
        {
            return new List<List<string>>();
        }

        private string insert(String query)
        {
            return "";
        }

        private string update(String query)
        {
            return "";
        }

        private string delete(String query)
        {
            return "";
        }
    }
}
