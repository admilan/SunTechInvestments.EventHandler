using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SunTechInvestments.EventHandler.Application.Interface;
using SunTechInvestments.EventHandler.Domain.Entities;

namespace SunTechInvestments.EventHandler
{
    public class CustomerInfoHandleEvent
    {
        private readonly IProcessEvent _processEvent;

        public CustomerInfoHandleEvent(IProcessEvent processEvent)
        {
            _processEvent = processEvent;
        }

        [FunctionName("CustomerInfoHandleEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            if (req.Method == HttpMethods.Get)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string name = req.Query["name"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;

                string responseMessage = string.IsNullOrEmpty(name)
                    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                    : $"Hello, {name}. This HTTP triggered function executed successfully.";

                return new OkObjectResult(responseMessage);
            }
            else
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var eventObj = JsonConvert.DeserializeObject<CustomerInfoEvent>(requestBody);
                _processEvent.Process(eventObj);

                return new OkObjectResult(eventObj.Subject);
            }
        }
    }
}
