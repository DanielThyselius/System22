namespace PackageHandler.Tests;

public class PackageTests
{
    [Fact]
    public void CanCalculateVolumeOfNormalSizedCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        
        // We always round up because we are stingy
        var expected = 4713;
        
        // Act 
        var actual = sut.Volume();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfNormalSizedCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        sut.Weight = 2;
        var expected = 3770;

        // Act 
        var actual = sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfSuperLightCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        sut.Weight = 0;
        var expected = 3770;

        // Act 
        var actual = sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfLightCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        sut.Weight = 1;
        var expected = 3770;

        // Act 
        var actual = sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfSlightlyHeavyCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        sut.Weight = 3;
        var expected = 5655;

        // Act 
        var actual = sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfHeavyCylinder()
    {
        // Normal size is the size of a rolled up poster
        // Arrange
        var sut = new Package();
        sut.Radius = 5;
        sut.Length = 60;
        sut.Weight = 8;
        var expected = 15080;

        // Act 
        var actual = sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void PriceDoesNotMutatePackage()
    {
        // Arrange
        var sut = new Package();
        var radius = 5;
        var len = 60;
        var weight = 1;
        
        sut.Radius = radius;
        sut.Length = len;
        sut.Weight = weight;

        // Act 
        sut.Price();

        // Assert
        // Compare original to values after calculating price
        Assert.Equal(radius, sut.Radius);
        Assert.Equal(len, sut.Length);
        Assert.Equal(weight, sut.Weight);
    }

}