using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1
{
    public class MessageProvider : IMessageProvider
    {
        private ILogger<MessageProvider> logger;

        public MessageProvider(ILogger<MessageProvider> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public string GetMessage(string name)
        {
            var message = $"Servas, {name}!";
            logger.LogInformation($"Got message for {name}: {message}!");
            return message;
        }
    }
}
