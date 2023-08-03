using SunTechInvestments.EventHandler.Domain.Entities;

namespace SunTechInvestments.EventHandler.Application.Interface
{
    public interface IProcessEvent
    {
        void Process(CustomerInfoEvent ciEvent);
    }
}