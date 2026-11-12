using System;

namespace DesignPattern.src.SOLID.S.BetterExample;

public class UserService
{
    public void Register(User user)
    {
        EmailSender emailSender = new EmailSender();
        emailSender.SendEmail(user.Email, "Welcome to our platform");
    }
}
