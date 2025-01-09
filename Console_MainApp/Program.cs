using Console_MainApp.Dialogs;
using Business.Services; // För ContactService och FileService
using Business.Interfaces; // För IContactService och IContactRepository
using Business.Repositories; // För ContactRepository

class Program
{
    static void Main(string[] args)
    {
        // Skapa en instans av FileService
        string directoryPath = "Data"; // Specificera mappen där data ska sparas
        string fileName = "contacts.json"; // Filnamnet för att lagra kontakter
        IFileService fileService = new FileService(directoryPath, fileName);

        // Skapa en instans av ContactRepository med FileService
        IContactRepository contactRepository = new ContactRepository(fileService);

        // Skapa en instans av ContactService med ContactRepository
        IContactService contactService = new ContactService(contactRepository);

        // Skicka ContactService till MenuDialogs
        var dialog = new MenuDialogs(contactService);

        // Starta huvudmenyn
        dialog.MainMenu();
    }
}


