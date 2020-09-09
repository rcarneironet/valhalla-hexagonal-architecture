using Flunt.Notifications;
using System;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Modules.Domain.ValueObjects;

namespace Valhalla.Modules.Application.Commands.PlaceOrder
{
    public sealed class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;

        //produtos, customer e order mockados para fins de exemplo
        private Product _teclado;
        private Product _mouse;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public PlaceOrderUseCase(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public Guid Execute(Guid customerId)
        {
            Customer customer = _customerReadOnlyRepository.Get(customerId);
            if (customer == null)
            {
                AddNotification("Customer", "Customer does not exist.");
            }

            //Simular dados
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("contato@academiadotnet.com.br");

            _teclado = new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10);
            _mouse = new Product("Mouse Microsoft", "Melhor mouse", "mouse.jpg", 5M, 10);
            _monitor = new Product("Dell", "Melhor monitor", "dell.jpg", 50M, 10);

            _customer = new Customer(name, cpf, email, "11-5555-5555");
            _order = new Order(_customer);

            //Validar
            name.Validate();
            cpf.Validate();
            email.Validate();

            if (Invalid)
                AddNotification("Order", "Algo deu errado na sua ordem.");

            return customer.Id;

        }
    }
}
