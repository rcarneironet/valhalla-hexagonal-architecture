using System;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Tests.Fakes
{
    public class FakeOrderWriteRepository : IOrderWriteRepository
    {
        public Guid PlaceOrder(Customer customer, Order order)
        {
            return Guid.NewGuid();
        }
    }
}
