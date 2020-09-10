using System;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Modules.Domain.ValueObjects;

namespace Valhalla.Tests.Fakes
{
    public class FakeCustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        public Customer Get(Guid id)
        {
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("88041300081");
            var email = new EmailVo("contato@academiadotnet.com.br");

            return new Customer(name, cpf, email, "(11) 99999-9999");
        }
    }
}
