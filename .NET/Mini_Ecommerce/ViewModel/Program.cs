using Models;
using Repositories;
using ViewModel.Utils;

namespace ViewModel
{
    public class Program
    {
        static void Main(string[] args)
        {
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
                choice = Inputter.Inter(
                    "Select choice: ",
                    1, 4,
                    false
                );

                switch (choice)
                {
                    case 1:
                        ManageProduct();
                        break;
                    case 2:
                        RegisterCustomer();
                        break;
                    case 3:
                        PlaceAnOrder();
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

        static void ManageProduct()
        {
            var productRepo = new ProductRepository("product.json");
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
                            "Enter Name:",
                            true
                        );

                        decimal productPrice = Inputter.Decimaler(
                            "Enter Price:",
                            decimal.MinValue, decimal.MaxValue,
                            true
                        );

                        int productStock = Inputter.Inter(
                            "Enter Stock: ",
                            int.MinValue, int.MaxValue,
                            true
                        );

                        Product product = new Product
                        {
                            Name = productName,
                            Price = productPrice,
                            Stock = productStock
                        };

                        productRepo.Add(product);
                        Console.WriteLine("Product added!!!");
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
                        string productId = Inputter.NormalStringer(
                            "Enter product ID: ",
                            false
                        );

                        try
                        {
                            var guid = Guid.Parse(productId); // may throw if invalid format
                            var product1 = productRepo.GetById(guid);

                            if (product1 != null)
                            {
                                string newProductName = Inputter.NormalStringer(
                                    "Enter new name: ",
                                    false
                                );

                                decimal newProductPrice = Inputter.Decimaler(
                                    "Enter new price: ",
                                    decimal.MinValue, decimal.MaxValue,
                                    true
                                );

                                int newProductStock = Inputter.Inter(
                                    "Enter new Stock: ",
                                    int.MinValue, int.MaxValue,
                                    true
                                );

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

                        break;
                    case 4:
                        string productDelId = Inputter.NormalStringer(
                            "Enter product ID: ",
                            false
                        );

                        try
                        {
                            var guid = Guid.Parse(productDelId);
                            var product2 = productRepo.GetById(guid);

                            if (product2 != null)
                            {
                                productRepo.Delete(product2);
                                Console.WriteLine("Product deleted successfully");
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
                            Console.WriteLine($"An unexpected error occured: {ex.Message}");
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

        static void RegisterCustomer()
        {
            var customerRepo = new CustomerRepository("customer.json");

            string customerName = Inputter.NormalStringer(
                "Enter name: ",
                false
            );

            string customerEmail = Inputter.NormalStringer(
                "Enter email: ",
                false
            );

            customerRepo.Add(new Customer
            {
                Name = customerName,
                Email = customerEmail,
            });

            Console.WriteLine("Customer created!!!");
        }

        static void PlaceAnOrder()
        {

        }
    }
}
