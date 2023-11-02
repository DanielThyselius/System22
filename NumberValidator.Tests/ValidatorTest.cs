using System.ComponentModel.DataAnnotations;

namespace NumberValidator.Tests
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("0-306-40615-2")]
        [InlineData("3-598-21508-8")]
        [InlineData("99-85214-24-X")]
        [InlineData("99-85214-24X")]
        [InlineData("99-8521424X")]
        [InlineData("998521424X")]
        public void ValidIsbn10ShouldReturnTrue(string isbn)
        {
            test(isbn, true);
        }

        [Theory]
        [InlineData("0-306-40615-8")]
        [InlineData("3-598-21508-1")]
        [InlineData("99-852124X")]
        [InlineData("99-852424X")]
        [InlineData("998521424")]
        public void InValidIsbn10ShouldReturnFalse(string isbn)
        {
            test(isbn, false);
        }

        private static void test(string isbn, bool expected)
        {

            // Arrange
            var validator = new Validator();

            // Act
            bool actual = validator.IsValidIsbn10(isbn);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}