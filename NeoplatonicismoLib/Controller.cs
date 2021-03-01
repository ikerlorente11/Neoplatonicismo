using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class Controller
    {
        public static void executeQuery(String query)
        {
            switch (query.Split(' ')[0].ToLower())
            {
                case "create":
                    create(query);
                    break;
                case "drop":
                    drop(query);
                    break;
                case "select":
                    select(query);
                    break;
                case "insert":
                    insert(query);
                    break;
                case "update":
                    update(query);
                    break;
                case "delete":
                    delete(query);
                    break;
            }
        }

        public static void create(String query)
        {

        }

        public static void drop(String query)
        {

        }

        public static void select(String query)
        {

        }

        public static void insert(String query)
        {

        }

        public static void update(String query)
        {

        }

        public static void delete(String query)
        {

        }
    }
}
