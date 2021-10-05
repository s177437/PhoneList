using System;
using System.Collections.Generic;
using PhoneList.Events;
using PhoneList.Models;

namespace PhoneList.Data
{
    public interface IContactsRepo
    {
        event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void CreateContact(Contact contact);
        bool SaveChanges();
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}