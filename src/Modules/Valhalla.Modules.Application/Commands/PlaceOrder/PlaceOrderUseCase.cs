using Flunt.Notifications;
using System;
using System.Linq;
using Valhalla.Modules.Application.DistributedMessaging;
using Valhalla.Modules.Application.Inputs.Order;
using Valhalla.Modules.Application.Repositories;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Modules.Domain.ValueObjects;

namespace Valhalla.Modules.Application.Commands.PlaceOrder
{
    public class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly IOrderWriteRepository _orderWriteOnlyRepository;
        private readonly IKafkaProducer _kafkaProducer;

        //mockados para demo
        private Customer _customer;
        private Order _order;

        public PlaceOrderUseCase(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOrderWriteRepository orderWriteOnlyRepository,
            IKafkaProducer kafkaProducer)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
            _kafkaProducer = kafkaProducer;
        }



        //To-DO: criar uma padrão para retorno com smart notification
        public string Execute(PlaceOrderInput order)
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
            _customer = new Customer(name, cpf, email, "11-5555-5555");

            if (_customer.Invalid)
            {
                AddNotification("Cliente", "Erros identificados nos dados de cliente: ");
                return _customer.Notifications.FirstOrDefault().Message;
            }

            _order = new Order(_customer);
            var product = new Product(order.ProductItem.Title, order.ProductItem.Description, order.ProductItem.Image, order.ProductItem.Price, 10);
            _order.AddItem(product, order.ProductItem.Quantity);

            if (_order.Invalid)
            {
                AddNotification("Pedido", "Erros identificados nos dados do seu pedido: ");
                return _order.Notifications.FirstOrDefault().Message;
            }

            string orderId;

            try
            {
                orderId = _orderWriteOnlyRepository.PlaceOrder(_customer, _order);

                _kafkaProducer.Produce(orderId);
            }
            catch (Exception ex)
            {
                //TO-DO: Implement log
                throw;
            }

            return "Número do pedido: " + orderId;
        }
    }
}
