# C# Design Patterns and OOP Guide

> An e-book style guide to the concepts implemented in this repository.

## About This Book

This repository demonstrates object-oriented programming principles through small, executable C# examples. Read the chapters in order for a structured introduction, or use the reference sections for targeted study.

**Audience:** Beginner to intermediate C# developers  
**Language:** C# / .NET 10  
**Project:** `DesignPattern`

---

## Table of Contents

### Part I - Foundations

1. [Getting Started](#getting-started)
2. [Project Structure](#project-structure)
3. [Object-Oriented Relationships](#object-oriented-relationships)
4. [UML Reading Guide](#uml-reading-guide)

### Part II - OOP Principles

5. [Abstraction](#5-abstraction)
6. [Encapsulation](#6-encapsulation)
7. [Inheritance](#7-inheritance)
8. [Polymorphism](#8-polymorphism)

### Part III - Object Design

9. [Composition](#9-composition)
10. [Inheritance versus Composition](#10-inheritance-versus-composition)
11. [Fragile Base Class Problem](#11-fragile-base-class-problem)

### Part IV - Practice

12. [Examples and Exercises](#12-examples-and-exercises)
13. [Running the Repository](#running-the-repository)
14. [Concept Reference](#concept-reference)

---

## Getting Started

Object-oriented programming organizes a program into objects. A class defines a type of object, while an instance stores a particular state and can perform operations.

```csharp
BankAccount account = new BankAccount(100);
account.Deposit(50);
```

Key ideas include:

- A **class** is a reusable blueprint.
- An **object** is an instance of a class.
- A **field** stores object data.
- A **property** provides controlled access to data.
- A **method** performs an operation.
- A **namespace** organizes related types.

## Project Structure

```text
DesignPattern/
├── Program.cs
├── src/
│   ├── Abstraction/
│   ├── Encapsulation/
│   ├── Inheritance/
│   ├── Polymorphism/
│   ├── Composition/
│   └── Coupling/
└── docs/
    └── README.md
```

Each principle folder contains executable source code and a Markdown lesson.

## Object-Oriented Relationships

### `is-a`

Use inheritance when one class is a specialized type of another class.

- A `Car` is a `Vehicle`.
- A `Bike` is a `Vehicle`.
- A `SavingsAccount` is a `BankAccount`.

In UML, inheritance uses a hollow triangle arrow:

```mermaid
classDiagram
    class Vehicle
    class Car
    Vehicle <|-- Car
```

### `has-a`

Use composition or aggregation when an object contains or collaborates with another object.

- A `Car` has an `Engine`.
- A `Team` has `Player` objects.
- A `NotificationService` has an `INotificationChannel`.

In UML, composition uses a filled diamond and aggregation uses an unfilled diamond:

```mermaid
classDiagram
    class Car
    class Engine
    class Team
    class Player
    Car *-- Engine
    Team o-- Player
```

### Dependency

An object has a dependency when it uses a service or abstraction to perform work, even if it does not own that object.

```mermaid
classDiagram
    class NotificationService
    class INotificationChannel
    NotificationService --> INotificationChannel
```

## UML Reading Guide

| UML symbol | Meaning |
|---|---|
| `+` | Public member |
| `-` | Private member |
| `#` | Protected member |
| Hollow triangle | Inheritance or realization |
| Filled diamond | Composition |
| Unfilled diamond | Aggregation |
| Arrow | Association or dependency |

---

## 5. Abstraction

**Core idea:** Hide unnecessary implementation detail and expose meaningful operations.

**Relationship focus:** A caller may have an abstraction service dependency, while the service internally organizes complex work.

**Repository lesson:** [Abstraction.md](../src/Abstraction/Abstraction.md)  
**Example:** [EmailService.cs](../src/Abstraction/EmailService.cs)

```csharp
emailService.SendEmail();
```

The caller does not need to manually connect to the server, authenticate, send, and disconnect.

## 6. Encapsulation

**Core idea:** Protect object state and control access through validated operations.

**Relationship focus:** A `BankAccount` has a private balance that should not be changed directly.

**Repository lesson:** [Encapsulation.md](../src/Encapsulation/Encapsulation.md)  
**Examples:** [BankAccount.cs](../src/Encapsulation/BankAccount.cs), [BadBankAccount.cs](../src/Encapsulation/BadBankAccount.cs)

```csharp
BankAccount account = new BankAccount(100);
account.Deposit(50);
decimal balance = account.GetBalance();
```

## 7. Inheritance

**Core idea:** Reuse and specialize behavior through an `is-a` relationship.

**Repository lesson:** [Inheritance.md](../src/Inheritance/Inheritance.md)  
**Examples:** [Vehicle.cs](../src/Inheritance/Vehicle.cs), [Car.cs](../src/Inheritance/Car.cs), [Bike.cs](../src/Inheritance/Bike.cs)

```csharp
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
}
```

Inheritance is appropriate when derived classes are genuine subtypes of the base class and share a stable contract.

## 8. Polymorphism

**Core idea:** Different objects implement a shared operation in different ways.

**Relationship focus:** A `Car` and `Motorcycle` are both vehicles, so they are polymorphic through the `Vehicle` contract.

**Repository lesson:** [Polymorphism.md](../src/Polymorphism/Polymorphism.md)

```csharp
List<Vehicle> vehicles =
[
    new Car(),
    new Motorcycle()
];

foreach (Vehicle vehicle in vehicles)
{
    vehicle.Start();
}
```

## 9. Composition

**Core idea:** Build objects from smaller objects, behavior components, or services.

**Relationship focus:** A `Car` has an `Engine`; composition models a `has-a` relationship.

**Repository lesson:** [Composition.md](../src/Composition/Composition.md)

```csharp
public class Car
{
    private readonly Engine engine;

    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public void Start()
    {
        engine.Start();
    }
}
```

## 10. Inheritance versus Composition

| Decision | Prefer inheritance | Prefer composition |
|---|---|---|
| Relationship | Stable and genuine `is-a` | Flexible `has-a` or collaboration |
| Behavior | Shared subtype behavior | Replaceable or configurable components |
| Coupling | Tighter | Looser |
| Change risk | Higher in deep hierarchies | Lower when contracts are small |
| Example | `Car` is a `Vehicle` | `Car` has an `Engine` |

## 11. Fragile Base Class Problem

Inheritance can tightly couple derived classes to base-class implementation. A base-class change may unintentionally change derived behavior, making large hierarchies difficult to maintain.

Reduce the risk by:

- Using composition for replaceable behavior.
- Depending on interfaces rather than concrete implementations.
- Keeping inheritance hierarchies small and stable.
- Applying dependency inversion.
- Designing extensions through small contracts.

## 12. Examples and Exercises

### Exercise A: Relationship classifier

For each pair, decide whether the relationship is `is-a`, `has-a`, or a dependency:

1. `Car` and `Vehicle`
2. `Car` and `Engine`
3. `NotificationService` and `EmailChannel`
4. `SavingsAccount` and `BankAccount`
5. `House` and `Room`

### Exercise B: Encapsulate a library

Create a `Library` class with a private list of books. Expose methods to borrow and return a book. Add validation so a missing book cannot be borrowed.

### Exercise C: Change inheritance to composition

Create a notification hierarchy and then replace it with an `INotificationChannel` interface and a notification service that receives the channel through its constructor.

### Exercise D: Identify the fragile class

Choose a base class that has several derived classes. Explain which inherited methods could change unexpectedly and how composition could isolate the behavior.

## Running the Repository

Run these commands from the repository root in PowerShell:

```powershell
dotnet clean .\DesignPattern\DesignPattern.csproj
dotnet build .\DesignPattern\DesignPattern.csproj
dotnet run --project .\DesignPattern\DesignPattern.csproj -- abstraction
```

Available examples can also be selected by their command-line names, including:

- `encapsulation`
- `abstraction`
- `inheritance`
- `polymorphism`
- `coupling`

## Concept Reference

| Concept | Meaning |
|---|---|
| Abstraction | Exposes meaningful operations while hiding implementation detail |
| Encapsulation | Protects state and controls access |
| Inheritance | Creates subtype relationships through a base class |
| Polymorphism | Uses one operation contract for objects with different implementations |
| Composition | Builds objects from contained components or services |
| Aggregation | Contains objects that may exist independently |
| Coupling | The degree to which classes depend on one another |
| Interface | A contract implemented by classes |
| Dependency inversion | High-level code depends on abstractions rather than concrete details |
| Fragile base class | Base-class inheritance that makes derived classes unexpectedly fragile |

## Suggested Reading Order

1. [Abstraction](../src/Abstraction/Abstraction.md)
2. [Encapsulation](../src/Encapsulation/Encapsulation.md)
3. [Inheritance](../src/Inheritance/Inheritance.md)
4. [Polymorphism](../src/Polymorphism/Polymorphism.md)
5. [Composition](../src/Composition/Composition.md)

---

*End of guide.*
