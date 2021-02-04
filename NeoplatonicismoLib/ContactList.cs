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

        public List<Contact> getList()
        {
            return contacts;
        }

        public Contact findByName(String name)
        {
            foreach(Contact contact in contacts)
            {
                if(contact.getName().ToLower() == name.ToLower())
                    return contact;
            }
            return null;
        }

        public Contact findByEmail(String email)
        {
            foreach(Contact contact in contacts)
                {
                    if(contact.getEmail().ToLower() == email.ToLower())
                    {
                        return contact;
                    }
     
                }
            return null;
        }

        public int count()
        {
            return contacts.Count;
        }

        

        public String toString()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }
    }
}
