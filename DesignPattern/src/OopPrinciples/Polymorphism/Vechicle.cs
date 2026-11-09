using System;

namespace DesignPattern.src.OopPrinciples.Polymorphism;

public class Vehicle
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle is starting.");
    }

    public virtual void Stop()
    {
        Console.WriteLine("Vehicle is stopping.");
    }
}