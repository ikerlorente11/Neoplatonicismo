using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class TableColumn
    {
        String name;
        Type type;

        public TableColumn(String Name, Type Type)
        {
            name = Name;
            type = Type;
        }

        public String GetName()
        {
            return name;
        }

        public Type GetTypeValue()
        {
            return type;
        }

        public string ToFile()
        {
            if(type == typeof(string))
            {
                return name + "[4]" + "string";

            }else if(type == typeof(int))
            {
                return name + "[4]" + "int";

            }else if(type == typeof(double))
            {
                return name + "[4]" + "double";
            }
            else 
            { 
                return null; 
            }
            
        }
    }
}
