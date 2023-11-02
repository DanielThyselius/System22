using System.Diagnostics;

namespace TestabilityDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockDb = new MockDatabase();
            var mockDateTimeWrapper = new MockDateTimeWrapper();

            var sut = new PrintReceipt(mockDb, mockDateTimeWrapper);
            var item = "Bok";
            var quantity = 1;
            var price = 2;
            var discount = 25;
            var total = 1.5;
            var now = mockDateTimeWrapper.GetNow();
            Thread.Sleep(1000);

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
            var actual = sut.Execute(item, quantity);

            // Assert
            Assert.Equal(expected, actual);
            
        }
    }
}