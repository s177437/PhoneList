using System;
using System.Collections.Generic;
using System.Linq;
using PhoneList.Events;
using PhoneList.Models;

namespace PhoneList.Data
{
    public class SqlContactsRepo : IContactsRepo
    {

        private readonly ContactsContext _context;
        public event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;

        public SqlContactsRepo(ContactsContext context)
        {
            _context = context;
        }

        public void CreateContact(Contact contact)
        {
         if(contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
         if(OnTransactionProcessed != null)
            {
                OnTransactionProcessed(this, new TransactionProcessedEventArgs(contact));
            }
            _context.Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            return _context.Contacts.FirstOrDefault(p => p.Id == id); 
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateContact(Contact contact)
        {
            //No content
        }

    }
}
