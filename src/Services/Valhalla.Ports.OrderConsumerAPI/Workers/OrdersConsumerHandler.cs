using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Valhalla.Adapters.KafkaStreaming.Subscriber;

namespace Valhalla.Ports.OrderConsumerAPI.Workers
{
    public class OrdersConsumerHandler : IHostedService
    {
        private Timer _timer;
        private readonly IKafkaSubscriberAdapter _kafkaAdapter;
        public OrdersConsumerHandler(IKafkaSubscriberAdapter kafkaAdapter)
        {
            _kafkaAdapter = kafkaAdapter;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckSchedules, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void CheckSchedules(object state)
        {
            Console.WriteLine($"{DateTime.Now:o} => Rodando Consumidor de Ordens...");
            _kafkaAdapter.Subscribe();
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
