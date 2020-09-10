using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Valhalla.Modules.API.Handlers
{
    public class OrdersHandler : IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckSchedules, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(15));
            return Task.CompletedTask;
        }

        private void CheckSchedules(object state)
        {
            Console.WriteLine($"{DateTime.Now:o} => Running Orders Worker...");

            KafkaSubscribe();

        }

        private void KafkaSubscribe()
        {
            Console.WriteLine($"{DateTime.Now:o} => Checking for new orders...");

            var conf = new ConsumerConfig
            {
                GroupId = "order-consumer-group",
                BootstrapServers = "127.0.0.1:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<Ignore, string>(conf).Build();
            {
                c.Subscribe("orders-topic");

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);

                            //var value = JsonSerializer.Deserialize<Dto>(cr.Message.Value);

                            Console.WriteLine($"Consumiu ordem '{cr.Message.Value}' at: '{cr.TopicPartitionOffset}'.");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
