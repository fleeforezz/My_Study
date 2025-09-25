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
    public class OrderView
    {
        public void ManageOrder()
        {
            var orderService = new OrderService(
                new OrderRepository("customer.json"),
                new CustomerRepository("customer.json"),
                new ProductRepository("product.json")
            );
            int choice = 0;

            do
            {
                Console.WriteLine("\n1. Place an order");
                Console.WriteLine("2. Show order histtory for a customer");
                Console.WriteLine("3. Calculate total");
                Console.WriteLine("0. Return to main menu");
                Console.Write("Select choice: ");
                choice = Inputter.Inter(
                    "Select choice: ",
                    0, 3,
                    false
                );

                switch (choice)
                {
                    case 1:
                        PlaceAnOrder(orderService);
                        break;
                    case 2:
                        OrderHistory(orderService);
                        break;
                    case 3:
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            } while (choice > 0 && choice < 4);
        }

        // Place an order
        public void PlaceAnOrder(OrderService orderService)
        {
            string customerId = Inputter.NormalStringer(
                "Enter customer ID: ",
                false
            );

            var cart = new List<(Guid, int)>();

            string productId = Inputter.NormalStringer(
                "Enter product ID: ",
                false
            );

            int producQuantity = Inputter.Inter(
                "Enter quantity: ",
                1, int.MaxValue,
                false
            );

            cart.Add((Guid.Parse(productId), producQuantity));

            orderService.PlaceAnOrder(Guid.Parse(customerId), cart);
        }

        // Order History
        public void OrderHistory(OrderService orderService)
        {
            string customerId = Inputter.NormalStringer(
                "Enter customer ID: ",
                false
            );

            var orders = orderService.GetOrdersByCustomer(Guid.Parse(customerId));

            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Id}");
            }
        }
    }
}
