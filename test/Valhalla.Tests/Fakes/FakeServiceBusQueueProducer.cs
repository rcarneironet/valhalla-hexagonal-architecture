using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;
using Valhalla.Adapters.ServiceBus.QueueProducer;

namespace Valhalla.Tests.Fakes
{
    public class FakeServiceBusQueueProducer : IServiceBusQueueProducer
    {
        static ServiceBusClient? client;
        static ServiceBusSender? sender;

        public async Task AddMessageAsync(string queueName, string body)
        {
            client = new ServiceBusClient(ServiceBusConfiguration.ConnectionString);
            sender = client.CreateSender(queueName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(body)))
                throw new Exception($"The message is too large to fit in the batch.");

            try
            {
                await sender.SendMessagesAsync(messageBatch);
            }
            catch (Exception ex)
            {
                throw new Exception($"The message could not be sent to Service Bus: {ex?.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
