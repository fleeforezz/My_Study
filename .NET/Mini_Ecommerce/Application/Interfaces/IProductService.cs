using MiniEcommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEcommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> AddProductAsync(string name, decimal price, int stock);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task<ProductDto?> UpdateProductAsync(Guid id, string name, decimal price, int stock);
        Task<ProductDto?> DeleteProductAsync(Guid id);
    }
}
