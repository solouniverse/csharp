using DesignPattern.src.oopprinciples.abstraction;
using DesignPattern.src.oopprinciples.encapsulation;

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
    default:
        Console.WriteLine("Unknown choice. Use 'encapsulation' or 'abstraction'.");
        break;
}

static string SelectPrinciple()
{
    Console.WriteLine("Choose an example:");
    Console.WriteLine("1. Encapsulation");
    Console.WriteLine("2. Abstraction");
    Console.Write("Enter 1 or 2: ");

    return Console.ReadLine()?.Trim() switch
    {
        "1" => "encapsulation",
        "2" => "abstraction",
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
