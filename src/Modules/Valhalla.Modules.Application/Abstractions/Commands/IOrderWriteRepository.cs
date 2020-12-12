using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Abstractions.Commands
{
    public interface IOrderWriteRepository
    {
        string PlaceOrder(Customer customer, Order order);
    }
}
