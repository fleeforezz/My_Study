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
    public class CustomerView
    {
        public void RegisterCustomer()
        {
            var customerService = new CustomerService(new CustomerRepository("customer.json"));

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
    }
}
