using System;
using Valhalla.Modules.Application.Abstractions.Queries;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Adapters.SqlServerDataAccess.ReadOnlyRepositories
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
