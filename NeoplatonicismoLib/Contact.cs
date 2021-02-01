using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
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
    }
}
