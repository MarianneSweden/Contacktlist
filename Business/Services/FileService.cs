using System.Diagnostics;
using Business.Interfaces;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    // Konstruktor med standardvärden
    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    // Hämta innehåll från fil
    public string GetContentFromFile()
    {
        try
        {
            // Kontrollera om filen finns och returnera dess innehåll
            if (File.Exists(_filePath))
                return File.ReadAllText(_filePath);

            // Returnera tom sträng om filen inte finns
            return string.Empty;
        }
        catch (Exception ex)
        {
            // Logga eventuella fel
            Debug.WriteLine($"Error reading file: {ex.Message}");
            return string.Empty; // Säkerhetsåtgärd vid fel
        }
    }

    // Spara innehåll till fil
    public bool SaveContentToFile(string content)
    {
        try
        {
            // Kontrollera om mappen finns, annars skapa den
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            // Spara innehållet till fil
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            // Logga eventuella fel
            Debug.WriteLine($"Error saving file: {ex.Message}");
            return false; // Returnera false vid fel
        }
    }
}


