namespace DesignPattern.src.SOLID.I.BetterExample;

public class Circle : IShape2D
{
    public double Radius { get; set; }

    // public Circle(double radius)
    // {
    // 	Radius = radius;
    // }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}
