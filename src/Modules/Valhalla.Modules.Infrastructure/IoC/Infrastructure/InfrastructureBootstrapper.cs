using Microsoft.Extensions.DependencyInjection;
using Valhalla.Modules.Application.DistributedMessaging;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Infrastructure.DataAccess;
using Valhalla.Modules.Infrastructure.DistributedMessaging;

namespace Valhalla.Modules.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IKafkaProducer, KafkaProducer>();

        }
    }
}
