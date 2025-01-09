using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;

namespace Business.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IFileService _fileService;

        public ContactRepository(IFileService fileService)
        {
            _fileService = fileService;
        }

        // Spara kontaktlistan till fil
        public bool SaveContactListToFile(List<Contact> list)
        {
            try
            {
                // Serialisera listan till JSON
                var json = JsonSerializer.Serialize(list);

                // Spara JSON till fil via filhanteringstjänsten
                var result = _fileService.SaveContentToFile(json);
                return result;
            }
            catch (Exception ex)
            {
                // Logga felet
                Debug.WriteLine($"Error saving contacts to file: {ex.Message}");
                return false;
            }
        }

        // Hämta kontaktlistan från fil
        public List<Contact> GetContactsFromFile()
        {
            try
            {
                // Läs JSON-innehåll från fil via filhanteringstjänsten
                var json = _fileService.GetContentFromFile();

                if (!string.IsNullOrEmpty(json))
                {
                    // Deserialisera JSON till en lista med kontakter
                    return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                }
            }
            catch (Exception ex)
            {
                // Logga felet
                Debug.WriteLine($"Error loading contacts from file: {ex.Message}");
            }

            // Returnera en tom lista om något går fel
            return new List<Contact>();
        }
    }
}
