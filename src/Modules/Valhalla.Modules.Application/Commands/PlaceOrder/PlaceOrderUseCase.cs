using Flunt.Notifications;
using System.Linq;
using Valhalla.Adapters.KafkaStreaming.Producer;
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
        private readonly IKafkaAdapter _kafkaAdapter;

        //mockados para demo
        private Customer _customer;
        private Order _order;

        public PlaceOrderUseCase(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOrderWriteRepository orderWriteOnlyRepository,
            IKafkaAdapter kafkaAdapter)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
            _kafkaAdapter = kafkaAdapter;
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

                //Envia mensagem para Kafka
                _kafkaAdapter.Produce(orderId);
            }
            catch
            {
                throw;
            }

            return "Número do pedido: " + orderId;
        }
    }
}
