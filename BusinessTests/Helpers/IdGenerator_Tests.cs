using Business.Helpers; // För att testa IdGenerator
using Xunit; // För testattribut och assertions

namespace BusinessTests.Helpers
{
    public class IdGenerator_Tests
    {
        [Fact]
        public void GenerateUniqueId_ShouldReturnNonNullValue()
        {
            // Act
            var id = IdGenerator.GenerateUniqueId();

            // Assert
            Assert.NotNull(id); // Kontrollera att det inte är null
            Assert.NotEmpty(id); // Kontrollera att det inte är tomt
        }

        [Fact]
        public void GenerateUniqueId_ShouldReturnUniqueValues()
        {
            // Act
            var id1 = IdGenerator.GenerateUniqueId();
            var id2 = IdGenerator.GenerateUniqueId();

            // Assert
            Assert.NotEqual(id1, id2); // Kontrollera att ID:n är unika
        }
    }
}
