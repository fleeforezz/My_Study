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

        public void Delete(Product product)
        {
            var products = _db.Load().ToList();

            products.RemoveAll(p => p.Id == product.Id);
            _db.SaveChanges(products);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Load();
        }

        public Product GetById(Guid id)
        {
            return _db.Load().FirstOrDefault(p => p.Id == id);

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
