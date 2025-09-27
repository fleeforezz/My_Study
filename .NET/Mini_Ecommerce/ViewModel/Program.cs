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
            SearchView searchView = new SearchView();

            int choice = 0;

            do
            {
                Console.WriteLine("\n======== Mini E-commerce App ========");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Order Management");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Reports");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");
                choice = Inputter.Inter(
                    "Select choice: ",
                    0, 5,
                    false
                );

                switch (choice)
                {
                    case 1:
                        productView.ManageProduct();
                        break;
                    case 2:
                        customerView.ManageCustomer();
                        break;
                    case 3:
                        orderView.ManageOrder();
                        break;
                    case 4:
                        searchView.SearchProduct();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            }
            while (choice >= 0 && choice < 6);
        }
    }
}
