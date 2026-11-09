using System;

namespace DesignPattern.src.OopPrinciples.Coupling;

public class Order
{
    private readonly INotificationService notificationService;

    public Order(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }
    public void PlaceOrder()
    {
        /* EmailSender emailSender = new EmailSender();
        emailSender.SendNotification("Order placed successfully."); */
        notificationService.SendNotification("Order placed successfully.");
    }
}
