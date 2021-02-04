using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoplatonicismoLib
{
    public class ContactList
    {
        List<Contact> contacts = new List<Contact>();

        public void add(Contact contact)
        {
            contacts.Add(contact);
        }

        public Contact findByName(String name)
        {
            return contacts[0];
        }

        public Contact findByEmail(String email)
        {
            return contacts[0];
        }

        public int count()
        {
            return contacts.Count;
        }

        contacts First = null;

        public String toString()
        {
         Contact contact = First();
            string output = "[";

            while (contact != null)
            {
                 output += contact.Value + ",";
                 contact = contact.next;
            }
            output = output.TrimEnd(',') + "] " + count() + " elements";
      
            return output;
        }
    }
}
