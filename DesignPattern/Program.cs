using System;
using System.Collections;
using System.Collections.Generic;
using DesignPattern.src.OopPrinciples.Abstraction;
using DesignPattern.src.OopPrinciples.Encapsulation;
using PolymorphismNamespace = DesignPattern.src.OopPrinciples.Polymorphism;
using DesignPattern.src.OopPrinciples.Polymorphism.BadExample;
using InheritanceNamespace = DesignPattern.src.OopPrinciples.Inheritance;
using DesignPattern.src.OopPrinciples.Inheritance;
using DesignPattern.src.OopPrinciples.Coupling;
using System.Runtime.CompilerServices;
using CompositionNamespace = DesignPattern.src.OopPrinciples.Composition;

string choice = args.Length > 0
    ? args[0].ToLowerInvariant()
    : SelectPrinciple();

switch (choice)
{
    case "encapsulation":
        RunEncapsulationExample();
        break;
    case "abstraction":
        RunAbstractionExample();
        break;
    case "inheritance":
        RunInheritanceExample();
        break;
    case "polymorphism":
        RunPolymorphismExample();
        break;
    case "coupling":
        RunCouplingExample();
        break;
    case "composition":
        RunCompositionExample();
        break;
    default:
        Console.WriteLine("Unknown choice. Use 'encapsulation' or 'abstraction'.");
        break;
}

static string SelectPrinciple()
{
    Console.WriteLine("Choose an example:");
    Console.WriteLine("1. Encapsulation");
    Console.WriteLine("2. Abstraction");
    Console.WriteLine("3. Inheritance");
    Console.WriteLine("4. Polymorphism");
    Console.WriteLine("5. Coupling");
    Console.WriteLine("6. Composition");
    Console.Write("Enter your choice: ");

    return Console.ReadLine()?.Trim() switch
    {
        "1" => "encapsulation",
        "2" => "abstraction",
        "3" => "inheritance",
        "4" => "polymorphism",
        "5" => "coupling",
        "6" => "composition",
        _ => "unknown"
    };
}

static void RunEncapsulationExample()
{
    BankAccount account = new BankAccount(100);

    Console.WriteLine($"Initial balance: {account.GetBalance()}");
    account.Deposit(50);
    Console.WriteLine($"Balance after deposit: {account.GetBalance()}");
    account.withdraw(30);
    Console.WriteLine($"Balance after withdrawal: {account.GetBalance()}");
}

static void RunAbstractionExample()
{
    EmailService emailService = new EmailService();
    emailService.SendEmail();
}

static void RunInheritanceExample()
{
    var car = new InheritanceNamespace.Car();

    // shared
    car.Brand = "Ford";
    car.Model = "Bronco";
    car.Year = 2026;

    car.Start();
    car.Stop();

    // unique
    car.NumberOfDoors = 4;
    car.NumberOfWheels = 4;

    var bike = new InheritanceNamespace.Bike();

    bike.Brand = "";
    bike.Model = "";
    bike.Year = 2026;

    bike.NumberOfWheels = 2;
}

static void RunPolymorphismExample()
{
    /*     List<object> vehicles = new List<object>();
        vehicles.Add(new Car { Brand = "Toyota", Model = "Camry", Year = 2026, NumberOfDoors = 4 });
        vehicles.Add(new Motorcycle { Brand = "Harley", Model = "Sportster", Year = 2026 });

        foreach (var vehicle in vehicles)
        {
            if (vehicle is Car)
            {
                var car = (Car)vehicle;
                car.Start();
            }
            else if (vehicle is Motorcycle)
            {
                var motorcycle = (Motorcycle)vehicle;
                motorcycle.Start();
            }
        } */

    List<PolymorphismNamespace.Vehicle> vehicles = new List<PolymorphismNamespace.Vehicle>();
    vehicles.Add(new PolymorphismNamespace.Car { Brand = "Toyota", Model = "Camry", Year = 2026, NumberOfDoors = 4 });
    vehicles.Add(new PolymorphismNamespace.Motorcycle { Brand = "Harley", Model = "Sportster", Year = 2026 });

    foreach (var vehicle in vehicles)
    {
        vehicle.Start();
    }
}

static void RunCouplingExample()
{
    var order = new Order(new EmailSender());
    order.PlaceOrder();

    var order2 = new Order(new SmsSender());
    order2.PlaceOrder();
}

static void RunCompositionExample()
{
    var car = new CompositionNamespace.Car();
    car.StartCar();
}