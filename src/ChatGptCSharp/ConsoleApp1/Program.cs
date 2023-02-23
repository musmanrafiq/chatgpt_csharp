using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Betalgo.GPT3.Based.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Setup.Configure();

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            /*var completionResult = await openAiService.Completions
                .CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = "What is a programming language?",
                Model = Models.TextDavinciV2,
                MaxTokens = 100,
                Temperature= 0.9f,
                N = 3
                });

            if (completionResult.Successful)
            {
                foreach(var choice in completionResult.Choices) {
                    Console.WriteLine(choice.Text);
                }
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }
                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }*/

            var imageRequest = await openAiService.Image
                .CreateImage(new ImageCreateRequest()
                {
                    Prompt = "Pakistan flag with blue background",
                    N = 2
                });
            if (imageRequest.Successful)
            {
                foreach (var choice in imageRequest.Results)
                {
                    Console.WriteLine(choice.Url);
                }
            }

        }
    }
}