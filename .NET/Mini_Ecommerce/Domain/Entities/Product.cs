using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = 0;
        public int StockQuantity { get; private set; } = 0;

        public Product(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required!!!");

            if (price <= 0) 
                throw new ArgumentException("Price must be greater than zero!!!");

            if (stock <= 0)
                throw new ArgumentException("Stock cannot be negative!!!");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            StockQuantity = stock;
        }

        // You can also add a domain constructor for creation logic if needed
        [JsonConstructor]
        public Product(Guid id, string name, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void UpdateDetails(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required!!!");

            if (price < 0)
                throw new ArgumentException("Price must be greater than zero!!!");

            if (StockQuantity < 0)
                throw new ArgumentException("Stock cannot be negative!!!");

            Name = name;
            Price = price;
            StockQuantity = stock;
        }

        public void IncreaseStock(int qty)
            => StockQuantity = qty;

        public void DecreaseStock(int qty)
        {
            if (qty > StockQuantity)
                throw new InvalidOperationException("Insufficent stock!!!");
            StockQuantity -= qty;
        }
    }
}
