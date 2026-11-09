namespace DesignPattern.src.OopPrinciples.Polymorphism.BadExample;

public class Car
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public int NumberOfDoors { get; set; }

    public void Start()
    {
        Console.WriteLine("Car is starting.");
    }

    public void Stop()
    {
        Console.WriteLine("Car is stopping.");
    }
}