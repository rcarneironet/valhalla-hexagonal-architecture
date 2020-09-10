namespace Valhalla.Modules.Application.DistributedMessaging
{
    public interface IKafkaProducer
    {
        public void Produce(object data);
    }
}
