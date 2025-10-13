using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class ProductService
    {
        //private ProductRepository _productRepo;

        //public ProductService(ProductRepository repo)
        //{
        //    _productRepo = repo;
        //}

        //// Get all product
        //public IEnumerable<Product> GetAllProduct()
        //{
        //    var products = _productRepo.GetAll();

        //    if (products == null)
        //    {
        //        Console.WriteLine("Product list is empty!!!");
        //        return Enumerable.Empty<Product>();
        //    }

        //    return products;
        //}

        //// Get product by id
        //public Product GetProductById(Guid id)
        //{
        //    return _productRepo.GetById(id);
        //}

        //// Get product by name
        //public IEnumerable<Product> GetAllProductByName(string name)
        //{
        //    var products = _productRepo.GetByName(name);

        //    if (products == null)
        //    {
        //        Console.WriteLine($"Cannot find any product for: {name}");
        //        return Enumerable.Empty<Product>();
        //    }

        //    return products;
        //}

        //// Get product by price range
        //public IEnumerable<Product> GetAllProductByPriceRange(decimal minPrice, decimal maxPrice)
        //{
        //    var products = _productRepo.GetByPriceRange(minPrice, maxPrice);

        //    if (products == null)
        //    {
        //        Console.WriteLine($"Cannot find any product in range: {minPrice}-{maxPrice}");
        //        return Enumerable.Empty<Product>();
        //    }

        //    return products;
        //}

        //// Add product
        //public void AddProduct(string name, decimal price, int stock)
        //{
        //    if (string.IsNullOrEmpty(name) || price < 0 || stock < 0)
        //    {
        //        throw new ArgumentException("Invalid product data");
        //    }

        //    var product = new Product
        //    {
        //        Name = name,
        //        Price = price,
        //        Stock = stock
        //    };

        //    _productRepo.Add(product);
        //}

        //// Update product
        //public void UpdateProduct(Guid id, string name, decimal price, int stock)
        //{
        //    var product = _productRepo.GetById(id);

        //    if (product == null)
        //    {
        //        throw new Exception("Product not found");
        //    }

        //    try
        //    {
        //        product.Name = name;
        //        product.Price = price;
        //        product.Stock = stock;

        //        _productRepo.Update(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //// Delete product
        //public void DeleteProduct(Guid id)
        //{
        //    _productRepo.Delete(id);
        //}
    }
}
