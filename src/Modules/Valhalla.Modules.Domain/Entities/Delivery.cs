using System;
using Valhalla.Modules.Domain.Enums;

namespace Valhalla.Modules.Domain.Entities
{
    public class Delivery : IEntity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }

        public EDeliveryStatus Status { get; private set; }

        public void Send()
        {
            Status = EDeliveryStatus.Sent;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}
