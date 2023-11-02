using System.Diagnostics;

namespace TestabilityDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new PrintReceipt();
            var item = "Bok";
            var quantity = 1;
            var price = 2;
            var discount = 0;
            var total = 2;
            var now = DateTime.Now;

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