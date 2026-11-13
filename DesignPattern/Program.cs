using System;
using DesignPattern.src.OopPrinciples.Abstraction;
using DesignPattern.src.OopPrinciples.Encapsulation;
using PolymorphismNamespace = DesignPattern.src.OopPrinciples.Polymorphism;
using InheritanceNamespace = DesignPattern.src.OopPrinciples.Inheritance;
using CouplingNamespace = DesignPattern.src.OopPrinciples.Coupling;
using CompositionNamespace = DesignPattern.src.OopPrinciples.Composition;
using SRPNamespace = DesignPattern.src.SOLID.S;
using LSPNamespace = DesignPattern.src.SOLID.L;
using OCPNamespace = DesignPattern.src.SOLID.O;
using ISPNamespace = DesignPattern.src.SOLID.I;
using DIPNamespace = DesignPattern.src.SOLID.D;

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

    SRPNamespace.BetterExample.UserService userService = new SRPNamespace.BetterExample.UserService();
    userService.Register(user_better);
}

static void RunOpenClosedPrincipleExample()
{
    Console.WriteLine("Open/Closed Principle: Bad example");
    OCPNamespace.BadExample.Shape circle = new OCPNamespace.BadExample.Shape();
    circle.Type = OCPNamespace.BadExample.ShapeType.Circle;
    circle.Radius = 2;

    double area_circle = circle.CalculateArea();
    Console.WriteLine($"Aread of circle: {area_circle}");

    OCPNamespace.BadExample.Shape rectangle = new OCPNamespace.BadExample.Shape();
    rectangle.Type = OCPNamespace.BadExample.ShapeType.Rectangle;
    rectangle.Length = 4;
    rectangle.Width = 4;

    double area_rectangle = rectangle.CalculateArea();
    Console.WriteLine($"Area of rectangle: {area_circle}");

    Console.WriteLine("Open/Closed Principle: Better example");
    OCPNamespace.BetterExample.Circle circle1 = new OCPNamespace.BetterExample.Circle();
    circle1.Radius = 2;
    double area_circle1 = circle.CalculateArea();
    Console.WriteLine($"Area of circle: {area_circle1}");

    OCPNamespace.BetterExample.Rectangle rectangle1 = new OCPNamespace.BetterExample.Rectangle();
    rectangle1.Length = 5;
    rectangle1.Width = 3;
    double area_rectangle1 = rectangle1.CalculateArea();
    Console.WriteLine($"Area of rectangle: {area_rectangle1}");

    OCPNamespace.BetterExample.Triangle triangle1 = new OCPNamespace.BetterExample.Triangle();
    triangle1.Base = 2;
    triangle1.Height = 5;
    double area_triangle1 = triangle1.CalculateArea();
    Console.WriteLine($"Area triangle: {area_triangle1}");
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
    // var circle = new ISPNamespace.BadExample.Circle(radius: 1);
    ISPNamespace.BadExample.Circle circle = new ISPNamespace.BadExample.Circle();
    circle.Radius = 3;
    double area_circle = circle.Area();
    Console.WriteLine($"Area of circle: {area_circle}");
    // System.Console.WriteLine($"Volume of circle: {circle.Volume()}");

    ISPNamespace.BadExample.Sphere sphere = new ISPNamespace.BadExample.Sphere();
    sphere.Radius = 4;
    double area_sphere = sphere.Area();
    double volume_sphere = sphere.Volume();

    Console.WriteLine($"Area of sphere: {area_sphere}");
    Console.WriteLine($"Volume of sphere: {volume_sphere}");

    ISPNamespace.BetterExample.Circle circle2 = new ISPNamespace.BetterExample.Circle();
    circle2.Radius = 3;
    double area_circle2 = circle2.Area();
    Console.WriteLine($"Area of circle: {area_circle2}");

    ISPNamespace.BetterExample.Sphere sphere2 = new ISPNamespace.BetterExample.Sphere();
    sphere2.Radius = 4;
    double area_sphere2 = sphere2.Area();
    double volume_sphere2 = sphere2.Volume();
    Console.WriteLine($"Area of sphere: {area_sphere2}");
    Console.WriteLine($"Volume of sphere: {volume_sphere2}");
}

static void RunDependencyInversionPrincipleExample()
{
    DIPNamespace.BadExample.Car car = new DIPNamespace.BadExample.Car();
    car.Start();

    DIPNamespace.BetterExample.Engine engine1 = new DIPNamespace.BetterExample.Engine();
    DIPNamespace.BetterExample.Car car1 = new DIPNamespace.BetterExample.Car(engine1);
    car1.StartCar();

    DIPNamespace.BetterExample.ElectricEngine electricEngine = new DIPNamespace.BetterExample.ElectricEngine();
    DIPNamespace.BetterExample.Car car2 = new DIPNamespace.BetterExample.Car(electricEngine);
    car2.StartCar();
}