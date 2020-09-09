using System;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Customer Get(Guid id);
    }
}
