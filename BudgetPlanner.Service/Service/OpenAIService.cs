using BudgetPlanner.Service.ServiceInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using OpenAI;
using OpenAI.Chat;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BudgetPlanner.Service.Service
{
    public class OpenAIService : IOpenAIService
    {
        private static string _apikey;

        public OpenAIService(IConfiguration configuration)
        {
            _apikey = configuration["OpenAI:ApiKey"];
        }

        public async Task<string>AskAIForCategory(string expenseName)
        {
            var modelName = "gpt-3.5-turbo";
            var client = new ChatClient(modelName, _apikey);
            var response = await client.CompleteChatAsync($"Categorize these expenses into  Essential or Non Essential   category:{expenseName}");
            Console.WriteLine($"Prompt is :: Categorize these expenses into  Essential or Non Essential category:{expenseName}");
            Console.Write(response);
            return response.Value.Content[0].Text;
        }
    }
}
