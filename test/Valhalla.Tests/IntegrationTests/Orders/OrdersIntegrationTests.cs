using Flunt.Notifications;
using NUnit.Framework;
using System;
using Valhalla.Modules.Application.Commands.PlaceOrder;
using Valhalla.Modules.Application.Inputs.Order;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Tests.Fakes;

namespace Valhalla.Tests.IntegrationTests.Orders
{
    public class OrdersIntegrationTests : Notifiable
    {
        [Test]
        public void OrderTests_PlaceOrder_ReturnOrderNumber()
        {
            PlaceOrderUseCase _placeOrder = new PlaceOrderUseCase(new FakeCustomerReadOnlyRepository(), new FakeOrderWriteRepository());
            Guid customerId = Guid.NewGuid();

            var orderInput = new PlaceOrderInput()
            {
                CustomerId = customerId,
                OrderItem = new OrderItem(new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10), 10)
            };

            Guid order = _placeOrder.Execute(orderInput);

            AddNotifications(_placeOrder.Notifications);

            Assert.AreEqual(true, !Invalid);
        }
    }
}
