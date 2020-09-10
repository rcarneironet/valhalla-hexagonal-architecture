using System;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Infrastructure.DataAccess
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        public Guid PlaceOrder(Customer customer, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
