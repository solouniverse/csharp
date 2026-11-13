namespace DesignPattern.src.SOLID.D.BadExample;

public class Car
{
    private Engine engine;

    public Car()
    {
        this.engine = new Engine();
    }

    public void Start()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}