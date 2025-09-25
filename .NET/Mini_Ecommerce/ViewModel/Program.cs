using Models;
using Repositories;
using Services;
using ViewModel.Utils;
using ViewModel.Views;

namespace ViewModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductView productView = new ProductView();
            CustomerView customerView = new CustomerView();
            OrderView orderView = new OrderView();

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
                        productView.ManageProduct();
                        break;
                    case 2:
                        customerView.RegisterCustomer();
                        break;
                    case 3:
                        orderView.PlaceAnOrder();
                        break;
                    case 4:
                        orderView.OrderHistory();
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
