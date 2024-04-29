using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Configurations;
using api.Interfaces;
using Microsoft.Extensions.Options;

namespace api.Service
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAIConfig _openAIConfig;
        public OpenAIService(IOptionsMonitor<OpenAIConfig> optionsMonitor)
        {
            _openAIConfig = optionsMonitor.CurrentValue;
        }
        public async Task<string> EvaluateText(string text)
        {
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("I will give you a text in turkish and you will response if it is positive , negative or neutral. You must only response positive, negative and neutral");
            chat.AppendUserInput(text);
            var response = await chat.GetResponseFromChatbotAsync();
            return response;
        }

        
    }
}