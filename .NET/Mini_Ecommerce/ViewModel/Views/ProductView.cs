using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Utils;

namespace ViewModel.Views
{
    public class ProductView
    {
        public void ManageProduct()
        {
            var productService = new ProductService(new ProductRepository("product.json"));
            int productChoice = 0;

            do
            {
                Console.WriteLine("1. Add new Product");
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

                        productService.AddProduct(productName, productPrice, productStock);

                        Console.WriteLine("Product added!!!");
                        break;

                    case 2:
                        foreach (var item in productService.GetAllProduct())
                        {
                            Console.WriteLine($"{item.Id} | {item.Name} | {item.Price} | {item.Stock}");
                        }
                        break;

                    case 3:

                        string productId = Inputter.NormalStringer("Enter product ID: ", false);

                        if (!Guid.TryParse(productId, out Guid parsedId))
                        {
                            Console.WriteLine("Invalid product ID format!!!");
                            return;
                        }

                        var product = productService.GetProductById(parsedId);
                        if (product == null)
                        {
                            Console.WriteLine("Product not found, update was cancelled!!!");
                            return;
                        }

                        string newProductName = Inputter.NormalStringer("Enter new name: ", true);
                        decimal newProductPrice = Inputter.Decimaler("Enter new price: ", 0, decimal.MaxValue, true);
                        int newProductStock = Inputter.Inter("Enter new stock: ", 0, int.MaxValue, true);

                        try
                        {
                            productService.UpdateProduct(parsedId, newProductName, newProductPrice, newProductStock);
                            Console.WriteLine("Prodcut updated!!!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Update product failed {ex.Message}");
                        }

                        break;
                    case 4:
                        string productDelId = Inputter.NormalStringer("Enter product ID: ", false);

                        if (!Guid.TryParse(productDelId, out parsedId))
                        {
                            Console.WriteLine("Invalid product ID format!!!");
                            return;
                        }

                        var productDel = productService.GetProductById(parsedId);
                        if (productDel == null)
                        {
                            Console.WriteLine("Product not found, update was cancelled!!!");
                            return;
                        }

                        try
                        {
                            productService.DeleteProduct(parsedId);
                            Console.WriteLine("Delete success!!!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to delete: {ex.Message}");
                        }

                        break;

                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            } while (productChoice > 0 && productChoice < 4);
        }
    }
}
