using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, int StockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required!!!");

            if (price <= 0) 
                throw new ArgumentException("Price must be greater than zero!!!");

            if (StockQuantity <= 0)
                throw new ArgumentException("Stock cannot be negative!!!");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Stock = StockQuantity;
        }

        public void IncreaseStock(int qty)
            => Stock = qty;

        public void DecreaseStock(int qty)
        {
            if (qty > Stock)
                throw new InvalidOperationException("Insufficent stock!!!");
            Stock -= qty;
        }
    }
}
