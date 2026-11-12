# Dependency Inversion Principle (DIP)

The Dependency Inversion Principle says:

1. High-level policy should not depend directly on low-level implementation details. Both should depend on abstractions.
2. Abstractions should not depend on details; details should depend on abstractions.

This principle is often used with dependency injection, where dependencies are supplied to a class instead of being created inside it.

## DIP in this repository

The order-notification example under OOP principles applies constructor injection:

- [`INotificationService.cs`](../../../src/OopPrinciples/Coupling/INotificationService.cs) defines the abstraction.
- [`Order.cs`](../../../src/OopPrinciples/Coupling/Order.cs) receives an `INotificationService` in its constructor and uses it when an order is placed.
- [`EmailSender.cs`](../../../src/OopPrinciples/Coupling/EmailSender.cs) and [`SmsSender.cs`](../../../src/OopPrinciples/Coupling/SmsSender.cs) are interchangeable implementations of that abstraction.

`Order` is the high-level policy and does not construct either concrete sender. The application chooses which implementation to provide. A commented-out direct construction in `Order.cs` shows the tighter coupling that constructor injection avoids.

## Example: Order notifications

### Before: high-level logic creates a concrete sender

```csharp
public class EmailSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public class OrderService
{
    private readonly EmailSender sender = new EmailSender();

    public void PlaceOrder()
    {
        // Save order...
        sender.Send("Order placed.");
    }
}
```

`OrderService` is tightly coupled to `EmailSender`. Switching to SMS or testing the order workflow requires changing or working around that concrete dependency.

### After: both depend on an abstraction

```csharp
public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public class OrderService
{
    private readonly INotificationSender sender;

    public OrderService(INotificationSender sender)
    {
        this.sender = sender;
    }

    public void PlaceOrder()
    {
        // Save order...
        sender.Send("Order placed.");
    }
}
```

The application supplies the implementation:

```csharp
var orderService = new OrderService(new EmailSender());
orderService.PlaceOrder();
```

An SMS sender or test double can also implement `INotificationSender` without changing `OrderService`.

## Relationship to composition

`OrderService` **has a dependency on** `INotificationSender`. The sender is injected through the constructor, so the high-level service can use different implementations without owning or constructing their concrete details.

## When to apply DIP

- High-level business logic constructs infrastructure dependencies directly.
- A class is difficult to test because it requires a real database, network service, or filesystem.
- Implementations should be replaceable without changing the policy that uses them.

DIP is about the direction of source-code dependencies; dependency injection is one technique for providing the implementation at runtime.

---

| ← [ISP](../I/InterfaceSegregationPrinciple.md) | [Book contents](../../README.md) | [Practice and exercises](../../README.md#17-examples-and-exercises) → |
|---|---|---|
