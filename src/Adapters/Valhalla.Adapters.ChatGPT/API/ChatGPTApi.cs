using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Valhalla.Adapters.ChatGPT.API
{
    public static class ChatGPTApi
    {
        public static async Task<string> GetResponse(string message)
        {
            var response = string.Empty;
            var completion = new CompletionRequest
            {
                Prompt = message,
                Model = Model.DavinciText,
                MaxTokens = 200
            };

            var chatGpt = new OpenAIAPI();
            var result = await chatGpt.Completions.CreateCompletionAsync(completion);

            result.Completions.ForEach(resultText => response = resultText.Text);

            return response;
        }
    }
}
