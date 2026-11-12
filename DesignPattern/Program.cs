using System;
using System.Collections;
using System.Collections.Generic;
using DesignPattern.src.OopPrinciples.Abstraction;
using DesignPattern.src.OopPrinciples.Encapsulation;
using PolymorphismNamespace = DesignPattern.src.OopPrinciples.Polymorphism;
using DesignPattern.src.OopPrinciples.Polymorphism.BadExample;
using InheritanceNamespace = DesignPattern.src.OopPrinciples.Inheritance;
using DesignPattern.src.OopPrinciples.Inheritance;
using CouplingNamespace = DesignPattern.src.OopPrinciples.Coupling;
using System.Runtime.CompilerServices;
using CompositionNamespace = DesignPattern.src.OopPrinciples.Composition;
using SRPNamespace = DesignPattern.src.SOLID.S;
using LSPNamespace = DesignPattern.src.SOLID.L;
using DesignPattern.src.SOLID.S.BetterExample;
// using DesignPattern.src.SOLID.L.BetterExample;

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
    // "Single Responsibility Principle (SRP)"
    case "srp":
        RunSingleResponsibilityPrincipleExample();
        break;
    // "Open/Closed Principle (OCP)"
    case "ocp":
        RunOpenClosedPrincipleExample();
        break;
    // "Liskove Substitution Principle (LSP)
    case "lsp":
        RunLiskovSubstitutionPrincipleExample();
        break;
    // Interface Segregation Principle (ISP)
    case "isp":
        RunIntefaceSegregationPrincipleExample();
        break;
    // "Dependency Inversion Principle (DIP)
    case "dip":
        RunDependencyInversionPrincipleExample();
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
    Console.WriteLine("7. SRP (Single Responsibility Principle)");
    Console.WriteLine("8. OCP (Open Closed Principle)");
    Console.WriteLine("9. LSP (Liskov Substitution Principle)");
    Console.WriteLine("10. ISP (Interface Segregation Principle)");
    Console.WriteLine("11. DIP (Dependency Inversion Principle)");
    Console.Write("Enter your choice: ");

    return Console.ReadLine()?.Trim() switch
    {
        "1" => "encapsulation",
        "2" => "abstraction",
        "3" => "inheritance",
        "4" => "polymorphism",
        "5" => "coupling",
        "6" => "composition",
        "7" => "srp",
        "8" => "ocp",
        "9" => "lsp",
        "10" => "isp",
        "11" => "dip",
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
    var order = new CouplingNamespace.Order(new CouplingNamespace.EmailSender());
    order.PlaceOrder();

    var order2 = new CouplingNamespace.Order(new CouplingNamespace.SmsSender());
    order2.PlaceOrder();
}

static void RunCompositionExample()
{
    var car = new CompositionNamespace.Car();
    car.StartCar();
}

static void RunSingleResponsibilityPrincipleExample()
{
    Console.WriteLine("Bad example");
    var user = new SRPNamespace.BadExample.User();
    user.Email = "solouniverse19@gmail.com";
    user.Username = "solouniverse";

    user.Register();

    Console.WriteLine("BetterExample");
    SRPNamespace.BetterExample.User user_better = new SRPNamespace.BetterExample.User();
    user_better.Email = "solouniverse19@gmail.com";
    user_better.Username = "solouniverse19";

    UserService userService = new UserService();
    userService.Register(user_better);
}

static void RunOpenClosedPrincipleExample()
{
    Console.WriteLine("Open/Closed Principle:");
    Console.WriteLine("A class should be open for extension, but closed for modification.");
    Console.WriteLine("Example: add a new discount rule without changing the original pricing logic.");
}

static void RunLiskovSubstitutionPrincipleExample()
{
    Console.WriteLine("Bad example");
    var rect = new LSPNamespace.BadExample.Rectangle();
    rect.Height = 10;
    rect.Width = 5;
    Console.WriteLine($"Expected area: 10 * 5 = {10 * 5}");
    Console.WriteLine($"Calculated area: {rect.Area}");

    var square = new LSPNamespace.BadExample.Square();
    square.Width = 10;
    square.Height = 5;
    Console.WriteLine($"Expected area: 10 * 5 = {10 * 5}");
    Console.WriteLine($"Calculated area: {square.Area}");

    Console.WriteLine("Better example");
    var rectangle = new LSPNamespace.BetterExample.Rectangle();
    rectangle.Width = 10;
    rectangle.Height = 5;
    Console.WriteLine($"Expected area: 10 * 5 = {10 * 5}");
    Console.WriteLine($"Calculated area: {rectangle.Area}");

    var sq = new LSPNamespace.BetterExample.Square();
    sq.Side = 5;
    Console.WriteLine($"Expected area: 5 * 5 = {5 * 5}");
    Console.WriteLine($"Calculated area: {sq.Area}");
}

static void RunIntefaceSegregationPrincipleExample()
{
    Console.WriteLine("Interface Segregation Principle:");
    Console.WriteLine("Clients should not be forced to implement methods they do not use.");
    Console.WriteLine("Example: split large interfaces into smaller, more specific ones.");
}

static void RunDependencyInversionPrincipleExample()
{

}