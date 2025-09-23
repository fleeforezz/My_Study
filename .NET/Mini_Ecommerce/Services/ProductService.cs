using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        private ProductRepository _productRepo;

        public ProductService(ProductRepository repo)
        {
            _productRepo = repo;
        }

        // Get all product service
        public IEnumerable<Product> GetAllProduct()
        {
            var products = _productRepo.GetAll();

            if (products == null)
            {
                Console.WriteLine("Product list is empty!!!");
                return Enumerable.Empty<Product>();
            }

            return products;
        }

        // Get product by id service
        public Product GetProductById(Guid id)
        {
            return _productRepo.GetById(id);
        }

        // Add product service
        public void AddProduct(string name, decimal price, int stock)
        {
            if (string.IsNullOrEmpty(name) || price < 0 || stock < 0)
            {
                throw new ArgumentException("Invalid product data");
            }

            var product = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            _productRepo.Add(product);
        }

        // Update product service
        public void UpdateProduct(Guid id, string name, decimal price, int stock)
        {
            var product = _productRepo.GetById(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            try
            {
                product.Name = name;
                product.Price = price;
                product.Stock = stock;

                _productRepo.Update(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete product service
        public void DeleteProduct(Guid id)
        {
            _productRepo.Delete(id);
        }
    }
}
