using FluentResults;
using SunTechInvestments.EventHandler.Domain.Entities;

namespace SunTechInvestments.EventHandler.Application.Interface;
public interface ICustomerInforEGClient
{
    Result PublishToEg(CustomerInfo data, string subject, string eventType, string dataVersion);
}
