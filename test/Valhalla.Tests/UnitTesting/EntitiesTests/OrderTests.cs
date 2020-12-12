using Flunt.Notifications;
using NUnit.Framework;
using System;
using Valhalla.Modules.Application.Commands.PlaceOrder;
using Valhalla.Modules.Domain.Entities;
using Valhalla.Modules.Domain.Enums;
using Valhalla.Modules.Domain.ValueObjects;
using Valhalla.Tests.Fakes;

namespace Valhalla.Tests.UnitTesting.EntitiesTests
{
    public class OrderTests : Notifiable
    {

        private Product _teclado;
        private Product _mouse;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            //Simular dados
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("contato@academiadotnet.com.br");

            _teclado = new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10);
            _mouse = new Product("Mouse Microsoft", "Melhor mouse", "mouse.jpg", 5M, 10);
            _monitor = new Product("Dell", "Melhor monitor", "dell.jpg", 50M, 10);

            _customer = new Customer(name, cpf, email, "11-5555-5555");
            _order = new Order(_customer);
        }


        [Test]
        public void OrderTests_CreateOrder_WhenValidReturnTrue()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        [Test]
        public void OrderTests_CreateOrder_WhenCreatedStatusIsCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [Test]
        public void OrderTests_CreateOrder_OrderItemMustBe2()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_teclado, 5);

            Assert.AreEqual(2, _order.Itens.Count);
        }

        [Test]
        public void OrderTests_AddItem_ShouldSubtract5FromStock()
        {
            _order.AddItem(_monitor, 5);

            Assert.AreEqual(5, _monitor.StockQuantity);
        }

        [Test]
        public void OrderTests_CreateOrder_ShouldHave2ShippingsIfHigherThan5()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }
    }
}
