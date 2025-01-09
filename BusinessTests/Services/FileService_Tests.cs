


using Business.Services;


namespace BusinessTests.Services
{
    public class FileService_Tests
    {
        private const string DirectoryPath = "TestData";
        private const string FileName = "test.json";
        private readonly string _filePath;

        public FileService_Tests()
        {
            _filePath = Path.Combine(DirectoryPath, FileName);
        }

        [Fact]
        public void GetContentFromFile_ShouldReturnContent_WhenFileExists()
        {
            // Arrange
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);

            File.WriteAllText(_filePath, "Test content");

            var fileService = new FileService(DirectoryPath, FileName);

            // Act
            var result = fileService.GetContentFromFile();

            // Assert
            Assert.Equal("Test content", result);

            // Cleanup
            File.Delete(_filePath);
            Directory.Delete(DirectoryPath);
        }

        [Fact]
        public void GetContentFromFile_ShouldReturnEmptyString_WhenFileDoesNotExist()
        {
            // Arrange
            if (Directory.Exists(DirectoryPath) && File.Exists(_filePath))
            {
                File.Delete(_filePath);
                Directory.Delete(DirectoryPath);
            }

            var fileService = new FileService(DirectoryPath, FileName);

            // Act
            var result = fileService.GetContentFromFile();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void SaveContentToFile_ShouldSaveContentCorrectly()
        {
            // Arrange
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);

            var fileService = new FileService(DirectoryPath, FileName);
            var content = "New test content";

            // Act
            var result = fileService.SaveContentToFile(content);

            // Assert
            Assert.True(result);
            Assert.Equal(content, File.ReadAllText(_filePath));

            // Cleanup
            File.Delete(_filePath);
            Directory.Delete(DirectoryPath);
        }

        [Fact]
        public void SaveContentToFile_ShouldReturnFalse_WhenExceptionOccurs()
        {
            // Arrange
            var invalidDirectoryPath = string.Empty; // Invalid path
            var fileService = new FileService(invalidDirectoryPath, FileName);

            // Act
            var result = fileService.SaveContentToFile("Test content");

            // Assert
            Assert.False(result);
        }
    }
}
