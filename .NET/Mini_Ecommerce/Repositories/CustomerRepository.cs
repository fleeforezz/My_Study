using Infrastructure.Persistence;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly FileDatabase<Customer> _db;

        public CustomerRepository(string filepath)
        {
            _db = new FileDatabase<Customer>(filepath);
        }

        public void Add(Customer customer)
        {
            var customers = _db.Load().ToList();

            customers.Add(customer);
            _db.SaveChanges(customers);
        }

        public void Delete(Guid id)
        {
            var customers = _db.Load().ToList();

            customers.RemoveAll(c => c.Id == id);
            _db.SaveChanges(customers);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Load();
        }

        public Customer GetById(Guid id)
        {
            return _db.Load().SingleOrDefault(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            var customers = _db.Load().ToList();
            var index = customers.FindIndex(c => c.Id == customer.Id);

            if (index != null)
            {
                customers[index] = customer;
                _db.SaveChanges(customers);
            }
        }
    }
}
