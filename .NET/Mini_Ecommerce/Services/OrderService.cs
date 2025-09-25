using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService
    {
        private OrderRepository _orderRepo;
        private CustomerRepository _customerRepo;
        private ProductRepository _productRepo;

        public OrderService(OrderRepository orderRepo, CustomerRepository customerRepo, ProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _productRepo = productRepo;
        }

        // Place an order service
        public void PlaceAnOrder(Guid customerId, List<(Guid productId, int quantity)> cart)
        {
            var customer = _customerRepo.GetById(customerId);

            var order = new Order { CustomerId = customerId };

            if (customer == null) 
                throw new ArgumentNullException($"Cannot find customer with id: {customerId}");

            foreach (var (productId, quantity) in cart)
            {
                var product = _productRepo.GetById(productId);
                if (product == null) continue;
                if (product.Stock < quantity)
                    throw new ArgumentException($"Not enough stock for {product.Name}");

                order.ListOfProduct.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    Price = product.Price,
                });

                product.Stock -= quantity;
                _productRepo.Update(product);
            }

            _orderRepo.Add(order);
            Console.WriteLine($"Order placed successfully for {customer.Name}. Total: {order.TotalPrice:C}");
        }

        // Get order by customer 
        public IEnumerable<Order> GetOrdersByCustomer(Guid customerId)
        {
            var orders = _orderRepo.GetAll().Where(o => o.CustomerId == customerId);

            if (orders == null)
            {
                throw new ArgumentNullException($"There are no order for customer: {customerId}");
            }

            return orders;
        }

        // Calculate total revenues
        public decimal GetTotalReveue()
        {
            return _orderRepo.GetAll().Sum(o => o.TotalPrice);
        }
    }
}
