using System;
using Microsoft.EntityFrameworkCore;
using PhoneList.Models;

namespace PhoneList.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> opt) : base(opt)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
