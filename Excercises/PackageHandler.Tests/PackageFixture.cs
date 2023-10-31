namespace PackageHandler.Tests;

public class PackageFixture
{
    public Package Normal { get; set; } = new Package();

    public PackageFixture()
    {
        // Normal size is the size of a rolled up poster
        Normal.Radius = 5;
        Normal.Length = 60;
        Normal.Weight = 2;
    }
}