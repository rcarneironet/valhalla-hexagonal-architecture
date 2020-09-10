using Flunt.Notifications;
using NUnit.Framework;
using System;
using Valhalla.Modules.Application.Commands.PlaceOrder;
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
            Guid order = _placeOrder.Execute(customerId);

            AddNotifications(_placeOrder.Notifications);

            Assert.AreEqual(true, !Invalid);
        }
    }
}
