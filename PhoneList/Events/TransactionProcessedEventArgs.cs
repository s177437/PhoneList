using System;
using PhoneList.Models;

namespace PhoneList.Events
{
    public class TransactionProcessedEventArgs : EventArgs
    {

        public Contact Contact { get; set; }

        public TransactionProcessedEventArgs(Contact contact)
        {
            Contact = contact;
        }

    }
}
