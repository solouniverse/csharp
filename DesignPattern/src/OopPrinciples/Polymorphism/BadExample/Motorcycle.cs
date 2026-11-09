namespace DesignPattern.src.OopPrinciples.Polymorphism.BadExample;

public class Motorcycle
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public void Start()
    {
        Console.WriteLine("Motorcycle is starting.");
    }

    public void Stop()
    {
        Console.WriteLine("Motorcycle is stopping.");
    }
}