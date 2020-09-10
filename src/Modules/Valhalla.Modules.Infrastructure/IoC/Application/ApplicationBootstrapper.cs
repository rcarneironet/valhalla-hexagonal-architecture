using Microsoft.Extensions.DependencyInjection;
using Valhalla.Modules.Application.Commands.PlaceOrder;

namespace Valhalla.Modules.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();

        }
    }
}
