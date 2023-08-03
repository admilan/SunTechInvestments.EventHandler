using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SunTechInvestments.EventHandler;
using SunTechInvestments.EventHandler.Application;
using SunTechInvestments.EventHandler.Application.Interface;
using SunTechInvestments.EventHandler.Infrastructure.EventGrid;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SunTechInvestments.EventHandler;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddTransient<ICustomerInforEGClient, CustomerInforEGClient>();
        builder.Services.AddTransient<IProcessEvent, ProcessEvent>();
        builder.Services.AddLogging();
    }
}
