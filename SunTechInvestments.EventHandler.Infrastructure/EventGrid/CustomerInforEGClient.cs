using Azure.Messaging.EventGrid;
using FluentResults;
using SunTechInvestments.EventHandler.Application.Interface;
using SunTechInvestments.EventHandler.Domain.Entities;

namespace SunTechInvestments.EventHandler.Infrastructure.EventGrid;
public class CustomerInforEGClient : ICustomerInforEGClient
{
    private readonly EventGridPublisherClient _publisherClient;

    public CustomerInforEGClient()
    {
        var endpoint = Environment.GetEnvironmentVariable("EventGridEndpoint");
        var accessKey = Environment.GetEnvironmentVariable("EventGridAccessKey");

        _publisherClient = new EventGridPublisherClient(new Uri(endpoint), new Azure.AzureKeyCredential(accessKey));
    }

    public Result PublishToEg(CustomerInfo data, string subject, string eventType, string dataVersion)
    {
        try
        {
            var item = new EventGridEvent(subject, eventType, dataVersion, data.ToString());
            _publisherClient.SendEvent(item);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
