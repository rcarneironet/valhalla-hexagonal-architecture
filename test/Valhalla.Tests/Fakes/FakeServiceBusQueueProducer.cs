using System.Threading.Tasks;
using Valhalla.Adapters.ServiceBus.QueueProducer;

namespace Valhalla.Tests.Fakes
{
    public class FakeServiceBusQueueProducer : IServiceBusQueueProducer
    {
        public Task AddMessageAsync(string queueName, string body)
        {
            return Task.CompletedTask;
        }
    }
}
