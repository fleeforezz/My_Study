using Models;
using Repositories;
using ViewModel.Utils;

namespace ViewModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productRepo = new ProductRepository("product.json");
            int choice = 0;

            do
            {
                Console.WriteLine("======== Mini E-commerce App ========");
                Console.WriteLine("1. Product Actions");
                Console.WriteLine("2. Register Customers");
                Console.WriteLine("3. Place an Order");
                Console.WriteLine("4. Show order history for customer");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int productChoice = 0;

                        do
                        {
                            Console.WriteLine("1. Add new Product");
                            Console.WriteLine("2. List all product");
                            Console.WriteLine("3. Update product");
                            Console.WriteLine("4. Delete product");
                            Console.WriteLine("0. Return to main menu");
                            Console.Write("Select choice: ");
                            productChoice = int.Parse(Console.ReadLine());

                            switch (productChoice)
                            {
                                case 1:
                                    string productName = Inputter.NormalStringer(
                                        "Enter Name:",
                                        "Input cannot be empty",
                                        true
                                    );

                                    int productPrice = Inputter.Inter(
                                        "Enter Price:",
                                        int.MinValue, int.MaxValue,
                                        true
                                    );

                                    Console.Write("Enter Stock: ");
                                    int productStock = int.Parse(Console.ReadLine());

                                    Product product = new Product
                                    {
                                        Name = productName,
                                        Price = productPrice,
                                        Stock = productStock
                                    };

                                    productRepo.Add(product);
                                    break;

                                case 2:
                                    if (productRepo.GetAll().ToList() == null)
                                    {
                                        Console.WriteLine("Product list is empty");
                                    }
                                    else
                                    {
                                        foreach (var item in productRepo.GetAll())
                                        {
                                            Console.WriteLine($"{item.Id} | {item.Name} | {item.Price} | {item.Stock}");
                                        }
                                    }
                                    break;

                                case 3:
                                    Console.Write("Enter product ID: ");
                                    string productId = Console.ReadLine();

                                    if (!string.IsNullOrWhiteSpace(productId))
                                    {
                                        try
                                        {
                                            var guid = Guid.Parse(productId); // may throw if invalid format
                                            var product1 = productRepo.GetById(guid);

                                            if (product1 != null)
                                            {
                                                Console.Write("Enter new name: ");
                                                string newProductName = Console.ReadLine();
                                                Console.Write("Enter new price: ");
                                                decimal newProductPrice = decimal.Parse(Console.ReadLine());
                                                Console.Write("Enter new stock: ");
                                                int newProductStock = int.Parse(Console.ReadLine());

                                                if (!string.IsNullOrWhiteSpace(newProductName) && newProductPrice >= 0 && newProductStock >= 0)
                                                {
                                                    product1.Name = newProductName;
                                                    product1.Price = newProductPrice;
                                                    product1.Stock = newProductStock;

                                                    productRepo.Update(product1);
                                                    Console.WriteLine("Product updated successfully!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Input missing or invalid. Cancelled update!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"No product found with ID: {guid}");
                                            }
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid ID format. Please enter a valid GUID.");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Must enter product ID in order to update!");
                                    }

                                    break;
                                case 4:
                                    Console.Write("Enter product ID: ");
                                    string productDelId = Console.ReadLine();

                                    Product product2 = productRepo.GetById(Guid.Parse(productDelId));

                                    if (product2 != null)
                                    {

                                    }
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice!!!");
                                    break;
                            }
                        } while (choice > 0 && choice < 4);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            }
            while (choice > 0 && choice < 5);
        }
    }
}
