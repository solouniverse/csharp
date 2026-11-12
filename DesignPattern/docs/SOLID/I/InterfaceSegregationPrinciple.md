# Interface Segregation Principle (ISP)

The Interface Segregation Principle says that clients should not be forced to depend on methods they do not use.

Prefer small, focused interfaces for distinct capabilities instead of one large interface that every implementation must support.

## ISP in this repository

The notification example under OOP principles uses a small interface:

- [`INotificationService.cs`](../../../src/OopPrinciples/Coupling/INotificationService.cs) exposes only `SendNotification(string message)`.
- [`Order.cs`](../../../src/OopPrinciples/Coupling/Order.cs) depends on that notification capability.
- [`EmailSender.cs`](../../../src/OopPrinciples/Coupling/EmailSender.cs) and [`SmsSender.cs`](../../../src/OopPrinciples/Coupling/SmsSender.cs) implement it.

Because the interface contains one focused operation, its implementations are not forced to provide unrelated capabilities. This is a useful example of a small client-facing contract; the printer example below demonstrates the more explicit process of splitting a large interface into smaller ones. There is not currently a separate fat-interface/before-and-after example under `src/SOLID/I`.

## Example: Split a device interface

### Before: one interface has unrelated capabilities

```csharp
public interface IMultiFunctionDevice
{
    void Print(string document);
    void Scan(string document);
    void Fax(string document);
}
```

A basic printer that cannot scan or fax would have to provide meaningless implementations or throw exceptions.

### After: define focused interfaces

```csharp
public interface IPrinter
{
    void Print(string document);
}

public interface IScanner
{
    void Scan(string document);
}

public interface IFax
{
    void Fax(string document);
}
```

Implement only the capabilities the device supports:

```csharp
public class BasicPrinter : IPrinter
{
    public void Print(string document)
    {
        Console.WriteLine($"Printing: {document}");
    }
}

public class OfficeMachine : IPrinter, IScanner, IFax
{
    public void Print(string document) =>
        Console.WriteLine($"Printing: {document}");

    public void Scan(string document) =>
        Console.WriteLine($"Scanning: {document}");

    public void Fax(string document) =>
        Console.WriteLine($"Faxing: {document}");
}
```

## Relationship to other principles

An `OfficeMachine` implements several small contracts. It does not need to inherit from a large device class. Clients can depend only on the capability they use, such as `IPrinter`.

## When to apply ISP

- Implementations contain empty methods or throw `NotSupportedException` for parts of an interface.
- A small client change forces unrelated implementations to change.
- Different clients use distinct subsets of a large contract.

Keep interfaces cohesive: splitting every method into its own interface can make the design harder to understand without improving client independence.

---

| ← [LSP](../L/LiskovSubstitutionPrinciple.md) | [Book contents](../../README.md) | [DIP](../D/DependencyInversionPrinciple.md) → |
|---|---|---|
