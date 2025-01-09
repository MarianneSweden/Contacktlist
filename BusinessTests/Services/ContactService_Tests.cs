using Business.Models;
using Business.Interfaces;
using Business.Services;
using Moq; 


namespace BusinessTests.Services 
{
    public class ContactService_Tests
    {
        [Fact]
        public void CreateContact_ShouldCallSaveContactListToFile()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            mockRepository.Setup(r => r.SaveContactListToFile(It.IsAny<List<Contact>>())).Returns(true);

            var service = new ContactService(mockRepository.Object);
            var contact = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            // Act
            var result = service.CreateContact(contact);

            // Assert
            Assert.True(result); // Kontrollera att metoden returnerade true
            mockRepository.Verify(r => r.SaveContactListToFile(It.IsAny<List<Contact>>()), Times.Once); // Kontrollera att SaveContactListToFile kallades
        }

        [Fact]
        public void CreateContact_ShouldGenerateUniqueIdForNewContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            mockRepository.Setup(r => r.SaveContactListToFile(It.IsAny<List<Contact>>())).Returns(true);

            var service = new ContactService(mockRepository.Object);
            var contact = new Contact
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com"
            };

            // Act
            service.CreateContact(contact);

            // Assert
            Assert.False(string.IsNullOrEmpty(contact.Id)); // Kontrollera att ID genererades
        }
    }
}
