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
            var currentProduct = _db.Load().FirstOrDefault(p => p.Id == product.Id);

            if (currentProduct != null)
            {
                products.Remove(currentProduct);
                _db.SaveChanges(products);
            }
            else
            {
                Console.WriteLine("Cannot find target product to delete");
            }
            
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _db.Load();
            if (products == null)
            {
                Console.WriteLine("List of product is empty!!!");
            }

            return products;
        }

        public Product GetById(Guid id)
        {
            var product = _db.Load().FirstOrDefault(p => p.Id == id);
            try
            {
                if (product != null)
                {
                    return product;
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine($"Product with Id: {id} not found\n" + e);
            }

            return null;
            
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
