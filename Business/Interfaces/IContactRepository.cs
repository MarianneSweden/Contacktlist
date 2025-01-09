using Business.Models;



namespace Business.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContactsFromFile();
        bool SaveContactListToFile(List<Contact> list);
    }
}