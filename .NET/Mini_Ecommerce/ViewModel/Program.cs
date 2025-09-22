using Repositories;

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
                        } while (choice > 0 && choice < 5);
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
