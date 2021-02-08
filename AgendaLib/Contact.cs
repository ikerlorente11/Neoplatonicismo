using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaLib
{
    public class Contact
    {
        String name;
        String phone;
        String email;

        public Contact (String Name, String Phone = null, String Email = null)
        {
            name = Name;
            phone = Phone;
            email = Email;
        }

        public string getName ()
        {
            return name;
        }

        public String getEmail()
        {
           return email;
        }

        public String ToString()
        {
            return name + "," + phone + "," + email;
        }
    }
}
