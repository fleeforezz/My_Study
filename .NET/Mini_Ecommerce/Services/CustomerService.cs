using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService
    {
        private CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository repo)
        {
            _customerRepo = repo;
        }

        // Get all customer service
        public IEnumerable<Customer> GetAllCustomer()
        {
            var customers = _customerRepo.GetAll();

            if (customers == null)
            {
                Console.WriteLine("Customer list is empty!!!");
                return Enumerable.Empty<Customer>();
            }

            return customers;
        }

        // Add new customer service
        public void AddCustomer(string name, string email)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Invalid customer data!!!");
            }

            Customer customer = new Customer
            {
                Name = name,
                Email = email
            };

            _customerRepo.Add(customer);
            Console.WriteLine("Customer created!!!");
        }

        // Get customer by id
        public Customer GetCustomer(Guid id)
        {
            var customer = _customerRepo.GetById(id);

            if (customer == null)
            {
                throw new ArgumentNullException($"Cannot find customer with id: {id}");
            }

            return customer;
        }

        // Delete customer
        // Update customer
    }
}
