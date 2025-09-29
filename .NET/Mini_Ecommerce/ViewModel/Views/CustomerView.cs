using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Views
{
    public class CustomerView
    {
        public void ManageCustomer()
        {
            var customerService = new CustomerService(new CustomerRepository("customer.json"));
            int choice = 0;

            do
            {
                Console.WriteLine("\n1. Register a customer");
                Console.WriteLine("2. View customers");
                Console.WriteLine("0. Return to main menu");
                Console.Write("Select choice: ");
                choice = Inputter.Inter(
                    "Select choice: ",
                    0, 2,
                    false
                );

                switch (choice)
                {
                    case 1:
                        RegisterCustomer(customerService);
                        break;
                    case 2:
                        ViewCustomers(customerService);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            } while (choice > 0 && choice < 3);
        }

        private void RegisterCustomer(CustomerService customerService)
        {
            string customerName = Inputter.NormalStringer(
                "Enter name: ",
                false
            );

            string customerEmail = Inputter.NormalStringer(
                "Enter email: ",
                false
            );

            customerService.AddCustomer(customerName, customerEmail);
        }

        private void ViewCustomers(CustomerService customerService)
        {
            foreach (var customer in customerService.GetAllCustomer())
            {
                Console.WriteLine($"{customer.Id} | {customer.Name} | {customer.Email}");
            }
        }
    }
}
