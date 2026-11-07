// Encapsulation
/* using DesignPattern.src.oopprinciples.encapsulation;

BankAccount account = new BankAccount(-100);
Console.WriteLine(account.GetBalance());

account.Deposit(50);
Console.WriteLine(account.GetBalance());

account.withdraw(150);
Console.WriteLine(account.GetBalance()); */

// Abstraction
// Reduce complexity by hiding unnecessary details.

using DesignPattern.src.oopprinciples.abstraction;

EmailService emailService = new EmailService();
emailService.Connect();
emailService.Authenticate();
emailService.SendEmail();
emailService.Disconnect();



