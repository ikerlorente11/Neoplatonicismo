using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoplatonicismoLib;

namespace Agenda
{
	class Program
	{
		static void Main(string[] args)
		{
            String path = "BaseDeDatos.txt";
            ContactList contacts = new ContactList();
			contacts.add(new Contact("Pepe", "111111111", "pepe@pepe.com"));
			contacts.add(new Contact("Laura", "222222222", "laura@laura.com"));

            foreach (Contact contact in contacts.getList())
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(contact.ToString());
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    sw.WriteLine(contact.ToString());
                }
            }

            String db = File.ReadAllText(path);
            string[] dbContacts = db.Split('\n');
            dbContacts = dbContacts.Take(dbContacts.Count() - 1).ToArray();

            ContactList bdContactList = new ContactList();
            foreach (String contact in dbContacts)
            {
                string[] fields = contact.Split(',');

                Contact bdContact = new Contact(fields[0], fields[1], fields[2]);
                bdContactList.add(bdContact);
            }

            bdContactList.ToString();
		}
	}
}
