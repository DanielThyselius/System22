namespace PackageHandler.Tests;

[Collection(nameof(PackageCollection))]
public class PackageTests
{
    Package _sut;

    public PackageTests(PackageFixture packageFixture)
    {
        _sut = packageFixture.Normal;
    }

    [Fact]
    public void CanCalculateVolumeOfNormalSizedCylinder()
    {
        // Arrange
     
        // We always round up because we are stingy
        var expected = 4713;
        
        // Act 
        var actual = _sut.Volume();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfNormalSizedCylinder()
    {
        // Arrange
        var expected = 3770;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfSuperLightCylinder()
    {
        // Arrange
        _sut.Weight = 0;
        var expected = 3770;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfLightCylinder()
    {
        // Arrange
        _sut.Weight = 1;
        var expected = 3770;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfSlightlyHeavyCylinder()
    {
        // Arrange
        _sut.Weight = 3;
        var expected = 5655;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanCalculatePriceOfHeavyCylinder()
    {
        // Arrange
        _sut.Weight = 8;
        var expected = 15080;

        // Act 
        var actual = _sut.Price();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PriceDoesNotMutatePackage()
    {
        // Arrange
        _sut.Weight = 1;

        var radius = _sut.Radius;
        var len = _sut.Length;
        var weight = _sut.Weight;
        
        // Act 
        _sut.Price();

        // Assert
        // Compare original to values after calculating price
        Assert.Equal(radius, _sut.Radius);
        Assert.Equal(len, _sut.Length);
        Assert.Equal(weight, _sut.Weight);
    }

}
