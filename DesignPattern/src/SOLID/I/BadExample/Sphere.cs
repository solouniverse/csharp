namespace DesignPattern.src.SOLID.I.BadExample;

public class Sphere : IShape
{
    public double Radius { get; set; }
    public double Area()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }

    public double Volume()
    {
        double fraction = 4 / 3;
        return fraction * Math.PI * Math.Pow(Radius, 3);
    }
}