using System;
using Valhalla.Modules.Domain.Entities;

namespace Valhalla.Modules.Application.Abstractions.Queries
{
    public interface ICustomerReadOnlyRepository
    {
        Customer Get(Guid id);
    }
}
