using MiniEcommerce.Infrastructure.Persistence;
using MiniEcommerce.Application.Services;
using MiniEcommerce.Domain.Entities;
using MiniEcommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Views
{
    public class ProductView
    {
        public async Task ManageProduct()
        {
            // This is Manual Dependency Injection
            // 1. Build database layer
            var db = new FileDatabase<Product>("products.json");

            // 2. Create repository implementation
            IProductRepository repo = new ProductRepository(db);

            // 3. Inject repository implementation
            var productService = new ProductService(repo);

            int productChoice = 0;

            do
            {
                Console.WriteLine("\n1. Add new Product");
                Console.WriteLine("2. List all product");
                Console.WriteLine("3. Update product");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("0. Return to main menu");
                Console.Write("Select choice: ");
                productChoice = Inputter.Inter(
                    "Select choice: ",
                    1, 4,
                    false
                );

                switch (productChoice)
                {
                    case 1:
                        await AddProduct(productService);
                        break;
                    case 2:
                        await ListProduct(productService);
                        break;
                    case 3:
                        await UpdateProduct(productService);
                        break;
                    case 4:
                        await DeleteProduct(productService);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            } while (productChoice > 0 && productChoice < 4);
        }


        // Add product
        private async Task AddProduct(ProductService productService)
        {
            string productName = Inputter.NormalStringer(
                "Enter Name: ",
                true
            );

            decimal productPrice = Inputter.Decimaler(
                "Enter Price: ",
                decimal.MinValue, decimal.MaxValue,
                true
            );

            int productStock = Inputter.Inter(
                "Enter Stock: ",
                int.MinValue, int.MaxValue,
                true
            );

            await productService.AddProductAsync(productName, productPrice, productStock);

            Console.WriteLine("Product added!!!");
        }

        // List Product
        private async Task ListProduct(ProductService productService)
        {
            var products = await productService.GetAllAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.StockQuantity}");
            }
        }


        // Update Product
        private async Task UpdateProduct(ProductService productService)
        {
            string productId = Inputter.NormalStringer("Enter product ID: ", false);

            if (!Guid.TryParse(productId, out Guid parsedId))
            {
                Console.WriteLine("Invalid product ID format!!!");
                return;
            }

            string newProductName = Inputter.NormalStringer(
                "Enter new name: ",
                true
            );

            decimal newProductPrice = Inputter.Decimaler(
                "Enter new price: ",
                0, decimal.MaxValue,
                true
            );

            int newProductStock = Inputter.Inter(
                "Enter new stock: ",
                0, int.MaxValue,
                true
            );

            try
            {
                var updatedProduct = await productService.UpdateProductAsync(parsedId, newProductName, newProductPrice, newProductStock);
                if (updatedProduct == null)
                {
                    Console.WriteLine($"Cannot find product with ID: {parsedId}");
                    return;
                }
                Console.WriteLine("Prodcut updated!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update product failed {ex.Message}");
            }
        }


        // Delete Product
        private async Task DeleteProduct(ProductService productService)
        {
            string productDelId = Inputter.NormalStringer("Enter product ID: ", false);

            if (!Guid.TryParse(productDelId, out Guid parsedId))
            {
                Console.WriteLine("Invalid product ID format!!!");
                return;
            }

            try
            {
                var deletedProduct = await productService.DeleteProductAsync(parsedId);
                if (deletedProduct == null)
                {
                    Console.WriteLine($"Cannot find product with ID: {parsedId}");
                    return;
                }
                Console.WriteLine("Delete success!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete: {ex.Message}");
            }
        }
    }
}
