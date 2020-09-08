using System;

namespace Valhalla.Modules.Domain.Entities
{
    public class Product : IEntity
    {
        public Product(string title, string description, string image, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            StockQuantity = stockQuantity;
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public void WidthdrawStockQuantity(int quantity)
        {
            StockQuantity -= quantity;
        }

    }
}
