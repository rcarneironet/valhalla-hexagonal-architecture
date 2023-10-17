using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;
using Valhalla.Modules.Application.Commands.PlaceOrder;
using Valhalla.Modules.Application.UseCases.ChatGpt;

namespace Valhalla.Modules.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();            
            services.AddScoped<IChatGptUseCase, ChatGptUseCase>();

            //Chat GPT Key
            var chat = new OpenAIAPI("--key--");
            services.AddSingleton(chat);

        }
    }
}
