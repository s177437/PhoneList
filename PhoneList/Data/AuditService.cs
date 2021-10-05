using System;
using PhoneList.Data;
using PhoneList.Events;

namespace PhoneList.Data
{
    public class AuditService : IAuditService
    {
        public AuditService()
        {
        }

        public void Subscribe(IContactsRepo contactsRepo)
        {
            contactsRepo.OnTransactionProcessed += WriteAuditLog;
        }

        private void WriteAuditLog(object sender, TransactionProcessedEventArgs e)
        {
            Console.WriteLine($"AUDIT LOG: - Added the following contact - Name: {e.Contact.Name}, Age: ${e.Contact.Age}, Number: ${e.Contact.PhoneNumber}");
        }
    }
}
