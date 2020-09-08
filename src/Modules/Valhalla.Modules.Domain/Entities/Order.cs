using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using Valhalla.Modules.Domain.Enums;

namespace Valhalla.Modules.Domain.Entities
{
    public class Order : Notifiable, IEntity
    {
        private readonly IList<OrderItem> _itens;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            CreationDate = DateTime.UtcNow;
            Status = EOrderStatus.Created;
            _itens = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreationDate { get; private set; }
        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Itens => _itens.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        //Adicionar Item
        public void AddItem(Product product, int quantity)
        {
            if (quantity > product.StockQuantity)
            {
                AddNotification("OrderItem", $"Product {product.Title} does not have {quantity} in stock!");
            }

            var item = new OrderItem(product, quantity);
            _itens.Add(item);
        }

        //Cria um pedido
        public void Create()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_itens.Count == 0)
            {
                AddNotification("Order", "This order does not have itens");
            }
        }

        //Pagar
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar -> Se 5 itens, fazer 2 deliveries
        public void Ship()
        {
            var deliveries = new List<Delivery>();
            var count = 1;

            foreach (var item in _itens)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //pegar todas as entregas e enviar
            deliveries.ForEach(x => x.Send());
            //adicionar entregas aos pedidos
            deliveries.ForEach(p => _deliveries.Add(p));
        }

    }
}
