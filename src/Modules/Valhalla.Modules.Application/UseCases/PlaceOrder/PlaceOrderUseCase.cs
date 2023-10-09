using Flunt.Notifications;
using System;
using System.Linq;
using System.Text.Json;
using Valhalla.Adapters.KafkaStreaming.Producer;
using Valhalla.Adapters.ServiceBus.QueueProducer;
using Valhalla.Modules.Application.Abstractions.Commands;
using Valhalla.Modules.Application.Inputs.Order;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Modules.Domain.ValueObjects;

namespace Valhalla.Modules.Application.Commands.PlaceOrder
{
    public class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
    {
        private readonly IOrderWriteRepository _orderWriteOnlyRepository;
        private readonly IKafkaAdapter _kafkaAdapter;
        private readonly IServiceBusQueueProducer _serviceBusQueueProducerAdapter;

        //mockados para demo
        private Customer _customer;
        private Order _order;

        public PlaceOrderUseCase(
            IOrderWriteRepository orderWriteOnlyRepository,
            IKafkaAdapter kafkaAdapter,
            IServiceBusQueueProducer serviceBusQueueProducerAdapter)
        {
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
            _kafkaAdapter = kafkaAdapter;
            _serviceBusQueueProducerAdapter = serviceBusQueueProducerAdapter;
        }

        public string Execute(PlaceOrderInput order)
        {
            //Simulação de dados e regras de negócios
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
                //Salva ordem no banco de dados
                orderId = _orderWriteOnlyRepository.PlaceOrder(_customer, _order);

                _kafkaAdapter.Produce(orderId);
                //_serviceBusQueueProducerAdapter.AddMessageAsync("votes", JsonSerializer.Serialize(_order));
            }
            catch
            {
                throw new Exception($"Error executing PlaceOrderUseCase > Execute()");
            }

            return "Número do pedido: " + orderId;
        }
    }
}
