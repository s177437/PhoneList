using System.Collections.Generic;
using PhoneList.Models;

namespace PhoneList.Data
{
    public interface IContactsRepo
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void CreateContact(Contact contact);
        bool SaveChanges();
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}