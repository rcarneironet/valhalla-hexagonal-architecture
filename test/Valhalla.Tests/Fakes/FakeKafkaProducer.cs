using Valhalla.Adapters.KafkaStreaming.Producer;

namespace Valhalla.Tests.Fakes
{
    public class FakeKafkaProducer : IKafkaAdapter
    {
        public void Produce(object data)
        {
        }
    }
}
