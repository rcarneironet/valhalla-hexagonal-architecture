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
        private readonly IOrderWriteRepository _orderWriteOnlyRepository;

        //produtos, customer e order mockados para fins de exemplo
        private Product _teclado;
        private Product _mouse;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public PlaceOrderUseCase(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOrderWriteRepository orderWriteOnlyRepository)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
        }

        public Guid Execute(Guid customerId)
        {
            #region Obter dados do banco
            //Customer customer = _customerReadOnlyRepository.Get(customerId);
            //if (customer == null)
            //{
            //    AddNotification("Customer", "Customer does not exist.");
            //}
            #endregion

            //Simulando dados, não implementei acesso a dados
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("contato@academiadotnet.com.br");

            _teclado = new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10);
            _mouse = new Product("Mouse Microsoft", "Melhor mouse", "mouse.jpg", 5M, 10);
            _monitor = new Product("Dell", "Melhor monitor", "dell.jpg", 50M, 10);
            _customer = new Customer(name, cpf, email, "11-5555-5555");

            if (_customer.Invalid)
            {
                AddNotification("Order", "Algo deu errado na sua ordem: " + _customer.Notifications.ToString());
                return Guid.Empty;
            }

            _order = new Order(_customer);

            Guid? order;

            try
            {
                order = _orderWriteOnlyRepository.PlaceOrder(_customer, _order);
            }
            catch (Exception ex)
            {
                //TO-DO: Implement log
                throw;
            }

            return order.HasValue ? order.Value : Guid.Empty;
        }
    }
}
