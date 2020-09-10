using System;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Repositories
{
    public interface IOrderWriteRepository
    {
        string PlaceOrder(Customer customer, Order order);
    }
}
