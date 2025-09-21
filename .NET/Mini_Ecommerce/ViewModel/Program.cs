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
                Console.WriteLine("4. ");
            }
            while (choice >= 0 && choice < 5);
        }
    }
}
