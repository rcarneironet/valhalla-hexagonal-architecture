using System.Threading.Tasks;
using Valhalla.Adapters.ChatGPT.API;

namespace Valhalla.Modules.Application.UseCases.ChatGpt
{
    public interface IChatGptUseCase
    {
        Task<string> Execute(string message);
    }
    public class ChatGptUseCase : IChatGptUseCase
    {
        public async Task<string> Execute(string message)
        {
            return await ChatGPTApi.GetResponse(message);
        }
    }
}
