using System;
using System.Collections.Generic;
using Valhalla.Modules.Application.Queries;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Tests.Fakes
{
    public class FakeGetOrdersByCustomerQueries : IGetOrdersByCustomerQueries
    {
        public IEnumerable<Order> GetOrder(Guid orderId)
        {
            return new List<Order>();
        }
    }
}