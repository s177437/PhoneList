using System;
using System.Collections.Generic;
using System.Linq;
using PhoneList.Data;
using PhoneList.Events;
using PhoneList.Models;

namespace PhoneListTests
{
    public class MockContactsRepo : IContactsRepo
    {
        private readonly List<Contact> _contacts;
        public MockContactsRepo()
        {
            _contacts = new List<Contact>()
            {
                new Contact(){Id=1, Age="28", Name="Stian Strom Anderssen", PhoneNumber="92068960"},
                new Contact(){Id=2, Age="28", Name="Joakim Grevstad", PhoneNumber="41526313"},
                new Contact(){Id=3, Age="28", Name="Hallvard Flaa", PhoneNumber="95839596"},
            };
        }

        public event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;

        public void CreateContact(Contact contact)
        {
            var r = new Random();
            var id = r.Next(4, 40);
            contact.Id = id;
            if (OnTransactionProcessed != null)
            {
                OnTransactionProcessed(this, new TransactionProcessedEventArgs(contact));
            }
            _contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            return _contacts.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
