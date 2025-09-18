using Models;
using Repositories;

namespace ViewModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productRepo = new ProductRepository("product.json");

            while (true)
            {
                Console.WriteLine("\n=== E-Commerce Console App ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. List Orders");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter product price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        productRepo.Add(new Product { Name = name, Price = price });
                        Console.WriteLine("Product added!");

                        break;
                    case "2":
                        foreach (var product in productRepo.GetAll())
                        {
                            Console.WriteLine($"{product.Id} | {product.Name} | {product.Price}");
                        }

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");

                        break;
                }
            }
        }
    }
}
