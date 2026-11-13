namespace DesignPattern.src.SOLID.I.BadExample;

public class Circle : IShape
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

    public double Volume()
    {
        throw new InvalidOperationException("Volume not applicable for 2D shapes");
    }
}
