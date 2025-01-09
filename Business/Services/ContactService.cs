
using System.Diagnostics;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private List<Contact> _contacts = new();

        // Konstruktor
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // Skapa en ny kontakt
        public bool CreateContact(Contact contact)
        {
            try
            {
                contact.Id = IdGenerator.GenerateUniqueId(); // Generera ett unikt ID
                _contacts.Add(contact); // Lägg till kontakten i listan

                // Spara kontaktlistan till fil via repository
                var result = _contactRepository.SaveContactListToFile(_contacts);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error creating contact: {ex.Message}");
                return false;
            }
        }

        // Hämta alla kontakter
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                _contacts = _contactRepository.GetContactsFromFile(); // Ladda kontakter från fil
                return _contacts;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching contacts: {ex.Message}");
                return Enumerable.Empty<Contact>(); // Returnera tom lista vid fel
            }
        }

        // Hämta en specifik kontakt baserat på ett filter
        public Contact? GetContact(Func<Contact, bool> predicate)
        {
            // Returnera kontakt som matchar filtret, eller null om ingen hittas
            return _contacts.FirstOrDefault(predicate);
        }

        // Uppdatera en kontakt baserat på ett filter
        public bool UpdateContact(Func<Contact, bool> predicate, Contact updatedContact)
        {
            try
            {
                var contact = _contacts.FirstOrDefault(predicate);
                if (contact != null)
                {
                    // Uppdatera kontaktens fält
                    contact.FirstName = updatedContact.FirstName;
                    contact.LastName = updatedContact.LastName;
                    contact.Email = updatedContact.Email;
                    contact.PhoneNumber = updatedContact.PhoneNumber;
                    contact.StreetAddress = updatedContact.StreetAddress;
                    contact.PostalCode = updatedContact.PostalCode;
                    contact.City = updatedContact.City;

                    // Spara uppdaterad kontaktlista till fil
                    return _contactRepository.SaveContactListToFile(_contacts);
                }

                return false; // Ingen matchande kontakt hittades
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating contact: {ex.Message}");
                return false;
            }
        }

        // Ta bort en kontakt baserat på ett filter
        public bool DeleteContact(Func<Contact, bool> predicate)
        {
            try
            {
                var contact = _contacts.FirstOrDefault(predicate);
                if (contact != null)
                {
                    _contacts.Remove(contact); // Ta bort kontakten från listan

                    // Spara uppdaterad kontaktlista till fil
                    return _contactRepository.SaveContactListToFile(_contacts);
                }

                return false; // Ingen matchande kontakt hittades
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting contact: {ex.Message}");
                return false;
            }
        }
    }
}


