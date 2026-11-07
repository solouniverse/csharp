using System;

namespace DesignPattern.src.oopprinciples.abstraction;

public class EmailService
{
    public void SendEmail()
    {
        Connect();
        Authenticate();
        Console.WriteLine("Sending email...");
        Disconnect();
    }

    private void Connect()
    {
        Console.WriteLine("Connecting to email server...");
    }

    private void Authenticate()
    {
        Console.WriteLine("Authenticating...");
    }

    private void Disconnect()
    {
        Console.WriteLine("Disconnecting from email server...");
    }

}
