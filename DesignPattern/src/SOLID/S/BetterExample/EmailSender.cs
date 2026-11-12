using System;

namespace DesignPattern.src.SOLID.S.BetterExample;

public class EmailSender
{
    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Sending email to {email}: {message}");
    }
}