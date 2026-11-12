namespace DesignPattern.src.SOLID.S.BadExample;

public class EmailSender
{
    public void SendEmail(string message, string recipient)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}