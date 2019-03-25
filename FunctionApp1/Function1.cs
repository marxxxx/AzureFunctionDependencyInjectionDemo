using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public class Function1
    {
        public Function1(IMessageProvider messageProvider)
        {
            this.MessageProvider = messageProvider ?? throw new ArgumentNullException(nameof(messageProvider));
        }

        public IMessageProvider MessageProvider { get; }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var message = this.MessageProvider.GetMessage(name);

            return name != null
                ? (ActionResult)new OkObjectResult(message)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
