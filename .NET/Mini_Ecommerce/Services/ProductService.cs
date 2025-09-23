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
        private ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            product = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            productRepository.Add(product);
            return product;
        }
    }
}
