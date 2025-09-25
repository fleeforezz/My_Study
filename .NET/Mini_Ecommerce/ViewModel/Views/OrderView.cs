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
        public void PlaceAnOrder()
        {
            var orderService = new OrderService(
                new OrderRepository("order.json"),
                new CustomerRepository("customer.json"),
                new ProductRepository("product.json")
            );

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

        public void OrderHistory()
        {
            var orderService = new OrderService(
                new OrderRepository("order.json"),
                new CustomerRepository("customer.json"),
                new ProductRepository("product.json")
            );

            string customerId = Inputter.NormalStringer(
                "Enter customer ID: ",
                false
            );

            orderService.GetOrdersByCustomer(Guid.Parse(customerId));
        }
    }
}
