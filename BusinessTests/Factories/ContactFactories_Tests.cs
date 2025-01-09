
using Business.Factories;
using Business.Models;
using Xunit;

namespace BusinessTests.Factories
{
    public class ContactFactory_Tests
    {
        [Fact]
        public void Create_ShouldReturnNewContactInstance()
        {
            // Arrange
            // (Inga specifika förberedelser behövs här)

            // Act
            var contact = ContactFactory.Create();

            // Assert
            Assert.NotNull(contact); // Kontrollera att instansen inte är null
            Assert.IsType<Contact>(contact); // Kontrollera att det är en Contact-instans
        }

        [Fact]
        public void Create_ShouldReturnContactWithDefaultValues()
        {
            // Arrange
            // (Inga specifika förberedelser behövs här eftersom metoden skapar en ny instans)
            

            // Act
            var contact = ContactFactory.Create();

            // Assert
            Assert.NotNull(contact); // Kontrollera att instansen inte är null
            Assert.Null(contact.FirstName); // Förvänta att värdet är null
            Assert.Null(contact.LastName);
            Assert.Null(contact.Email);
            Assert.Null(contact.PhoneNumber);
            Assert.Null(contact.StreetAddress);
            Assert.Null(contact.PostalCode);
            Assert.Null(contact.City);
        }
    }
}





