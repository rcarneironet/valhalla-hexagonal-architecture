namespace Valhalla.Adapters.ServiceBus.QueueProducer
{
    public interface IServiceBusQueueProducer
    {
        Task AddMessageAsync(string queueName, string body);
    }
}
