using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductDto> AddProductAsync(string name, decimal price, int stock)
        {
            var product = new Product(name, price, stock);
            await _productRepo.AddAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = price,
                StockQuantity = stock
            };
        }
    }
}
