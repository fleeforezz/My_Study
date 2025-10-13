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

        public async Task<ProductDto?> DeleteProductAsync(Guid id)
        {
            var existing = await _productRepo.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            await _productRepo.DeleteAsync(id);

            return new ProductDto
            {
                Id = existing.Id,
                Name = existing.Name,
                Price = existing.Price,
                StockQuantity = existing.StockQuantity
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            }).ToList();
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };
        }

        public async Task<ProductDto?> UpdateProductAsync(Guid id, string name, decimal price, int stock)
        {
            var existing = await _productRepo.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.UpdateDetails(name, price, stock);
            await _productRepo.UpdateAsync(id, existing);
            return new ProductDto
            {
                Id = existing.Id,
                Name = existing.Name,
                Price = existing.Price,
                StockQuantity = existing.StockQuantity
            };
        }
    }
}
