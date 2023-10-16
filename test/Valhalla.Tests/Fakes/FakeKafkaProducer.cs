using Confluent.Kafka;
using System.Text.Json;
using Valhalla.Adapters.KafkaStreaming.Producer;

namespace Valhalla.Tests.Fakes
{
    public class FakeKafkaProducer : IKafkaAdapter
    {
        public void Produce(object data)
        {
            var config = new ProducerConfig { BootstrapServers = "127.0.0.1:9092" };
            using var p = new ProducerBuilder<Null, string>(config).Build();
            {
                try
                {
                    var dr = p.ProduceAsync("orders-topic",
                        new Message<Null, string>
                        {
                            Value = JsonSerializer.Serialize(data)
                        });
                    p.Flush();
                }
                catch (ProduceException<Null, string> e)
                {
                    //please implement a better exception :)
                    _ = e.Error.Reason;
                }
            }
        }
    }
}
