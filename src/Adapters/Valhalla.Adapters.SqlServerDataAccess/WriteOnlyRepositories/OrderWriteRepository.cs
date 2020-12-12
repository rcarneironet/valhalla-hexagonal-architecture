using System;
using System.Linq;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Adapters.SqlServerDataAccess.WriteOnlyRepositories
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        public string PlaceOrder(Customer customer, Order order)
        {
            const string characters = "0123456789" +
                                                  "abcdefghijklmnopqrstuvwxyz" +
                                                  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var random = new Random();
            return new string(Enumerable.Repeat(characters, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
