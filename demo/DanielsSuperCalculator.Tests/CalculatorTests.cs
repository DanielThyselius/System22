namespace DanielsSuperCalculator.Tests;

public class CalculatorTests
{

    [Fact]
    public void CanAddTwoAndTwo()
    {
        // Arrange
        var sut = new Calculator();
        var expected = 4;

        // Act
        var actual = sut.Add(2, 2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsDivideByZeroExceptionOnDivisionByZero()
    {
        // Arrange
        var sut = new Calculator();

        // Act
        // Assert
        Assert.Throws<DivideByZeroException>(() =>
        {
            var answer = sut.Divide(2, 0);
            Console.WriteLine(answer);
        });
    }

    [Fact]
    public void CalculatorIsInitiallyCalledBob()
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        
        // Assert
        Assert.Equal("Bob", sut.Name);
    }
}