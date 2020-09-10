using System;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Inputs.Order
{
    public sealed class PlaceOrderInput
    {
        public Guid CustomerId { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
