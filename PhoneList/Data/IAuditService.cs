using PhoneList.Data;

namespace PhoneList.Data
{
    public interface IAuditService
    {
        void Subscribe(IContactsRepo contactsRepo);
    }
}