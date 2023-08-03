namespace SunTechInvestments.EventHandler.Domain.Entities;

public class CustomerInfoEvent
{
    public string EventType { get; set; }
    public string Subject { get; set; }
    public CustomerInfo Customer { get; set; }
}
