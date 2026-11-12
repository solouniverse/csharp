using System;

namespace DesignPattern.src.SOLID.O.BetterExample;

public class Circle : Shape
{
    public double Radius {get;set;}
    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
