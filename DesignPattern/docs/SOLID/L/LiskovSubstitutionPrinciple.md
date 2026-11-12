# Liskov Substitution Principle (LSP)

> Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.

In practical terms, a subtype must honor the promises made by its base type. It should not unexpectedly reject valid inputs, weaken guarantees, or change the meaning of inherited operations.

## LSP in this repository

The shape hierarchy in the OCP example provides a shared contract that can be used to discuss substitution:

- [`Shape.cs`](../../../src/SOLID/O/BetterExample/Shape.cs) declares the `CalculateArea()` operation.
- [`Circle.cs`](../../../src/SOLID/O/BetterExample/Circle.cs), [`Rectangle.cs`](../../../src/SOLID/O/BetterExample/Rectangle.cs), and [`Triangle.cs`](../../../src/SOLID/O/BetterExample/Triangle.cs) are concrete shapes that implement it.

Code that accepts a `Shape` can call `CalculateArea()` without needing to know which concrete shape it received. For this to satisfy LSP, each implementation must preserve the operation's expected meaning and return the correct area. The abstract method alone does not guarantee that behavior; each subclass must honor the contract.

The mutable `Rectangle`/`Square` counterexample below is a teaching example in this document, not a class currently present in the repository.

## Example: A sound shape contract

### Before: a subtype breaks the base contract

```csharp
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int Area => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        get => base.Width;
        set => base.Width = base.Height = value;
    }

    public override int Height
    {
        get => base.Height;
        set => base.Width = base.Height = value;
    }
}
```

Code that expects to set a rectangle's width independently may fail when given a `Square`:

```csharp
static void SetWidth(Rectangle rectangle)
{
    rectangle.Width = 4;
    rectangle.Height = 5;

    // Expected area is 20, but Square forces both dimensions to match.
    Console.WriteLine(rectangle.Area);
}
```

Although a square is mathematically a rectangle, this mutable `Rectangle` API promises independently changeable dimensions. `Square` cannot honor that promise.

### After: model the shared capability

If callers only need an area, use a contract that expresses that capability:

```csharp
public interface IShape
{
    int Area { get; }
}

public class Rectangle : IShape
{
    public int Width { get; }
    public int Height { get; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Area => Width * Height;
}

public class Square : IShape
{
    public int Side { get; }

    public Square(int side)
    {
        Side = side;
    }

    public int Area => Side * Side;
}
```

Now both shapes can be substituted where an `IShape` is expected, because the contract makes no promise about changing width and height independently.

## `is-a` and substitution

Inheritance expresses an `is-a` relationship, but that relationship alone does not guarantee safe substitution. Check whether every subtype can honor the base type's observable behavior.

## When to apply LSP

- A subtype overrides a method by throwing for inputs accepted by the base type.
- A subtype returns results that violate the base type's documented guarantees.
- Callers need type checks to avoid using base-class operations on a subtype.

Prefer a smaller, accurate abstraction over an inheritance relationship that cannot preserve its contract.

---

| ← [OCP](../O/OpenClosedPrinciple.md) | [Book contents](../../README.md) | [ISP](../I/InterfaceSegregationPrinciple.md) → |
|---|---|---|
