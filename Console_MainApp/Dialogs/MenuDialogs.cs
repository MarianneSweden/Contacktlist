using Business.Factories;

namespace Console_MainApp.Dialogs
{
    public class MenuDialogs
    {
        private readonly IContactService _contactService;

        public MenuDialogs(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******* CONTACT LIST ********");
                Console.WriteLine("1. Add new contact");
                Console.WriteLine("2. View all contacts");
                Console.WriteLine("3. Update contact");
                Console.WriteLine("4. Delete contact");
                Console.WriteLine("Q. Exit application");
                Console.WriteLine("*****************************");
                Console.Write("Enter option: ");
                var option = Console.ReadLine()?.ToUpper();

                switch (option)
                {
                    case "1":
                        AddNewContact();
                        break;
                    case "2":
                        ViewAllContact();
                        break;
                    case "3":
                        UpdateContact();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void AddNewContact()
        {
            var contact = ContactFactory.Create();

            Console.Clear();
            Console.WriteLine("******* Add New Contact **********");

            Console.Write("Enter Firstname: ");
            contact.FirstName = Console.ReadLine()!;

            Console.Write("Enter Lastname: ");
            contact.LastName = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine()!;

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter Street Address: ");
            contact.StreetAddress = Console.ReadLine()!;

            Console.Write("Enter Postal Code: ");
            contact.PostalCode = Console.ReadLine()!;

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine()!;

            var result = _contactService.CreateContact(contact);

            if (result)
                Console.WriteLine("Contact was created successfully.");
            else
                Console.WriteLine("Unable to create new contact.");

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        public void ViewAllContact()
        {
            Console.Clear();
            Console.WriteLine("******* View All Contacts ********");

            var contacts = _contactService.GetAllContacts();

            if (!contacts.Any())
            {
                OutputDialog("No contacts found. Press any key to go back.");
                return;
            }

            // Skriv ut alla kontakters information
            foreach (var contact in contacts)
            {
                Console.WriteLine("************************************");
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
                Console.WriteLine($"Created Date: {contact.CreatedDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine("************************************");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        // Uppdatera en kontakt
        public void UpdateContact()
        {
            Console.Clear();
            Console.WriteLine("******* UPDATE CONTACT ********");
            Console.Write("Enter the ID of the contact to update: ");
            var id = Console.ReadLine();

            var contact = _contactService.GetContact(c => c.Id == id);

            if (contact == null)
            {
                Console.WriteLine("Contact not found. Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Current Info: {contact.FirstName} {contact.LastName} ({contact.Email})");

            Console.Write("Enter new First Name (leave blank to keep current): ");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newFirstName)) contact.FirstName = newFirstName;

            Console.Write("Enter new Last Name (leave blank to keep current): ");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLastName)) contact.LastName = newLastName;

            Console.Write("Enter new Email (leave blank to keep current): ");
            var newEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(newEmail)) contact.Email = newEmail;

            var updated = _contactService.UpdateContact(c => c.Id == id, contact);

            Console.WriteLine(updated ? "Contact updated successfully!" : "Failed to update contact.");
            Console.ReadKey();
        }

        // Ta bort en kontakt
        public void DeleteContact()
        {
            Console.Clear();
            Console.WriteLine("******* DELETE CONTACT ********");
            Console.Write("Enter the ID of the contact to delete: ");
            var id = Console.ReadLine();

            var deleted = _contactService.DeleteContact(c => c.Id == id);

            Console.WriteLine(deleted ? "Contact deleted successfully!" : "Failed to delete contact or contact not found.");
            Console.ReadKey();
        }


        public void OutputDialog(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}


