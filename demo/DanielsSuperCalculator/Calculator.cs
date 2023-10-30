namespace DanielsSuperCalculator;

public class Calculator
{
    public string Name { get; private set; } = "Bob";

    
    public float Add(float a, float b)
    {
        return a + b;
    }

    public float Divide(float a, float b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        
        return a/b;
    }

}