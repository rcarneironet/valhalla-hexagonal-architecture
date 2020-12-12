using Confluent.Kafka;

namespace Valhalla.Adapters.KafkaStreaming.Subscriber
{
    public interface IKafkaSubscriberAdapter
    {
        public void Subscribe();
    }
}
