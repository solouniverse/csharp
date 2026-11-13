namespace DesignPattern.src.SOLID.D.BetterExample;

public class Car
{
    private IEngine engine;

    public Car(IEngine engine)
    {
        this.engine = engine;
    }

    public void StartCar()
    {
        this.engine.Start();
        Console.WriteLine("Car started");
    }
}