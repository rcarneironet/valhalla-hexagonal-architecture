using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Infrastructure.DataAccess
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        public string PlaceOrder(Customer customer, Order order)
        {
            return "0123456789";
        }
    }
}
