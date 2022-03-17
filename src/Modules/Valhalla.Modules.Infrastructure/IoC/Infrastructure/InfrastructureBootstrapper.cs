using Microsoft.Extensions.DependencyInjection;
using Valhalla.Adapters.KafkaStreaming.Producer;
using Valhalla.Adapters.ServiceBus.QueueProducer;
using Valhalla.Adapters.SqlServerDataAccess.ReadOnlyRepositories;
using Valhalla.Adapters.SqlServerDataAccess.WriteOnlyRepositories;
using Valhalla.Modules.Application.Abstractions.Commands;
using Valhalla.Modules.Application.Abstractions.Queries;

namespace Valhalla.Modules.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IKafkaAdapter, KafkaAdapterProducer>();
            services.AddScoped<IServiceBusQueueProducer, ServiceBusQueueProducer>();
        }
    }
}
