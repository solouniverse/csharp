using System.Xml.Schema;

namespace DesignPattern.src.SOLID.O.BetterExample;

public class Triangle : Shape
{
    private const double fraction = 0.5;

    public double Base { get; set; }

    public double Height { get; set; }

    public override double CalculateArea() => fraction * Base * Height;
}
