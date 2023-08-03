using SunTechInvestments.EventHandler.Application.Interface;
using SunTechInvestments.EventHandler.Domain.Entities;

namespace SunTechInvestments.EventHandler.Application;

public class ProcessEvent : IProcessEvent
{
    private readonly ICustomerInforEGClient _customerInforEGClient;
    public ProcessEvent(ICustomerInforEGClient client)
    {
        _customerInforEGClient = client;
    }

    public void Process(CustomerInfoEvent ciEvent)
    {
        _customerInforEGClient.PublishToEg(ciEvent.Customer, ciEvent.Subject, ciEvent.EventType, ciEvent.Subject);
    }
}
