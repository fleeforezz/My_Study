using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly FileDatabase<Product> _db;

        public ProductRepository(string filepath)
        {
            _db = new FileDatabase<Product>(filepath);
        }

        public void Add(Product product)
        {
            var products = _db.Load().ToList();
            products.Add(product);
            _db.SaveChanges(products);
        }

        public void Delete(Guid id)
        {
            var products = _db.Load().ToList();

            products.RemoveAll(p => p.Id == id);
            _db.SaveChanges(products);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Load();
        }

        public IEnumerable<Product> GetByName(string keyword)
        {
            return _db.Load()
                .Where(p => p.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }

        public IEnumerable<Product> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _db.Load()
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }

        public Product GetById(Guid id)
        {
            return _db.Load()
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var products = _db.Load().ToList();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index != null)
            {
                products[index] = product;
                _db.SaveChanges(products);
            }
        }
    }
}
