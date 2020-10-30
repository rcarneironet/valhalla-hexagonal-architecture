using Valhalla.Modules.Application.DistributedMessaging;

namespace Valhalla.Tests.Fakes
{
    public class FakeKafkaProducer : IKafkaProducer
    {
        public void Produce(object data)
        {            
        }
    }
}
