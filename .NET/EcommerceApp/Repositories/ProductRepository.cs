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
            _db.Save(products);
        }

        public void Delete(Guid id)
        {
            var products = _db.Load().ToList();
            var product = _db.Load().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
                _db.Save(products);
            }
            else
            {
                Console.WriteLine($"Cannot find product with id: {id}");
            }
        }

        public void DeleteAll()
        {
            _db.Save(new List<Product>());
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Load();
        }

        public Product GetById(Guid id)
        {
            return _db.Load().FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
