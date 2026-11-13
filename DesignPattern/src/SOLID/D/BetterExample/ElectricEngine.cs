using System;

namespace DesignPattern.src.SOLID.D.BetterExample;

public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine started");
    }
}
