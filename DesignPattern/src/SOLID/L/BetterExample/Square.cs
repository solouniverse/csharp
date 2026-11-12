namespace DesignPattern.src.SOLID.L.BetterExample;

public class Square : Shape
{
    private double side;

    public double Side
    {
        get { return side; }
        set { side = value; }
    }
    public override double Area => Side * Side;
}