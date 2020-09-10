using Confluent.Kafka;
using System.Text.Json;
using Valhalla.Modules.Application.DistributedMessaging;

namespace Valhalla.Modules.Infrastructure.DistributedMessaging
{
    public class KafkaProducer : IKafkaProducer
    {
        public void Produce(object data)
        {
            var config = new ProducerConfig { BootstrapServers = "127.0.0.1:9092" };
            using var p = new ProducerBuilder<Null, string>(config).Build();
            {
                try
                {
                    var dr = p.ProduceAsync("orders-topic",
                        new Message<Null, string> { Value = JsonSerializer.Serialize(data) });
                }
                catch (ProduceException<Null, string> e)
                {

                    string erro = e.Error.Reason;
                }
            }
        }
    }
}
