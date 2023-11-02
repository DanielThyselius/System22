using System.Diagnostics;

namespace TestabilityDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ReceiptLooksGood()
        {
            // Arrange
            var mockDb = new MockDatabase();
            var mockDateTimeWrapper = new MockDateTimeWrapper(isFriday: true);

            var sut = new PrintReceipt(mockDb, mockDateTimeWrapper);
            var item = "Bok";
            var quantity = 1;
            var price = 2;
            var discount = sut.GetDiscount();
            var total = sut.Total(quantity, discount, price);
            var now = mockDateTimeWrapper.GetNow();

            var expected = $"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: {discount}%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   {now}
                   ********************************
                   """;
            // Act
            var actual = sut.GenerateReceiptString(item, quantity);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(25, 1.5)]
        [InlineData(50, 1)]
        [InlineData(0, 2)]
        public void TotalCalculatesCorrectPrice(float discount, float expected)
        {
            // Arrange
            var mockDb = new MockDatabase();
            var mockDateTimeWrapper = new MockDateTimeWrapper();

            var sut = new PrintReceipt(mockDb, mockDateTimeWrapper);
            var quantity = 1;
            var price = 2;

            // Act
            var actual = sut.Total(quantity, discount, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 25)]
        [InlineData(false, 0)]
        public void DiscountWorks(bool isFriday, float expected)
        {
            // Arrange
            var mockDb = new MockDatabase();
            var mockDateTimeWrapper = new MockDateTimeWrapper(isFriday);

            var sut = new PrintReceipt(mockDb, mockDateTimeWrapper);
            var quantity = 1;
            var price = 2;

            // Act
            var actual = sut.GetDiscount();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}