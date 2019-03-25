using FunctionApp1;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(Startup))]
namespace FunctionApp1
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var services = builder.Services;
            services.AddTransient<IMessageProvider, MessageProvider>();
        }

        
    }
}
