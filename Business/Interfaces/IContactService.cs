
using Business.Models;

public interface IContactService
{

    // Skapar en ny kontakt och lägger till den i kontaktlistan.


    //True om kontakten skapades framgångsrikt, annars false.
    bool CreateContact(Contact contact);


    IEnumerable<Contact> GetAllContacts();


    Contact? GetContact(Func<Contact, bool> predicate);

    //Contact GetContact(Func<Contact, bool> predicate);



    bool UpdateContact(Func<Contact, bool> predicate, Contact updatedContact);
    bool DeleteContact(Func<Contact, bool> predicate);
}

