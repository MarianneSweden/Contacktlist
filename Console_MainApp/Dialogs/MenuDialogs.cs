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
                Console.WriteLine("Q. Exit application");
                Console.WriteLine("*****************************");
                Console.Write("Enter option: ");
                var option = Console.ReadLine()!.ToUpper();

                switch (option)
                {
                    case "1":
                        AddNewContact();
                        break;

                    case "2":
                        ViewAllContact();
                        break;

                    case "Q":
                        Console.WriteLine("Exiting application. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
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

        public void OutputDialog(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}

