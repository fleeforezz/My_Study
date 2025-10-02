using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly FileDatabase<Product> _db;

        public ProductRepository()
        {
            _db = new FileDatabase<Product>("products.json");
        }

        public async Task AddAsync(Product product)
        {
            var products = _db.Load();
            products.Add(product);
            _db.SaveChanges(products);
            await Task.CompletedTask; // Keep async signature
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _db.Load();
            return await Task.FromResult(products);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var products = _db.Load();
            return await Task.FromResult(products.FirstOrDefault(x => x.Id == id));
        }
    }
}
