using System;
using System.Collections.Generic;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Queries
{
    public interface IGetOrdersByCustomerQueries
    {
        IEnumerable<Order> GetOrder(Guid orderId);
    }
}