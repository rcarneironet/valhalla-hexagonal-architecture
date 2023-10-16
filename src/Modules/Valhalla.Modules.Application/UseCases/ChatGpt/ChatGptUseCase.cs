using System.Threading.Tasks;
using Valhalla.Adapters.ChatGPT.API;

namespace Valhalla.Modules.Application.UseCases.ChatGpt
{
    public class ChatGptUseCase
    {
        public async Task<string> Execute(string message)
        {
            return await ChatGPTApi.GetResponse(message);
        }
    }
}
