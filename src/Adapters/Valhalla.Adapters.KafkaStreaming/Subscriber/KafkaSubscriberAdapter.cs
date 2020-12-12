using Confluent.Kafka;
using System;
using System.Threading;

namespace Valhalla.Adapters.KafkaStreaming.Subscriber
{
    public sealed class KafkaSubscriberAdapter : IKafkaSubscriberAdapter
    {
        public void Subscribe()
        {
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
    }
}
