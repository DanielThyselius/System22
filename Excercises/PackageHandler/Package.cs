namespace PackageHandler;

public class Package
{
    public int Radius { get; set; }
    public int Length { get; set; }
    public int Weight { get; set; }

    public int Volume() => (int)(Radius * Radius * Math.PI * Length + 1);

    public int Price()
    {
        // Omkrets (cm) x längd (cm) x vikt.
        // Minsta vikt vid beräkning är 2 kg.

        var weight = (Weight < 2) ? 2 : Weight;
        var price = Radius * 2 * Math.PI * Length * weight + 1;
        
        return (int)price;
    }
}