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

        public ProductRepository(FileDatabase<Product> db)
        {
            _db = db;
        }

        public async Task AddAsync(Product product)
        {
            var products = _db.Load();
            products.Add(product);
            _db.SaveChanges(products);
            await Task.CompletedTask; // Keep async signature
        }

        public async Task DeleteAsync(Guid id)
        {
            var products = _db.Load();
            products.RemoveAll(product => product.Id == id);
            _db.SaveChanges(products);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _db.Load();
            return await Task.FromResult(products);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var products = _db.Load(); // Load from Json file

            return await Task.FromResult(products.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Product?> UpdateAsync(Guid id, Product updatedProduct)
        {
            var products = _db.Load();

            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return null; // Not found
            }

            // Update existing field - depending on what you allow to change
            existing.UpdateDetails(
                updatedProduct.Name,
                updatedProduct.Price,
                updatedProduct.StockQuantity
            );

            _db.SaveChanges(products);
            return await Task.FromResult(existing);
        }
    }
}
