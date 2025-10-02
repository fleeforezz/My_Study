using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderItem> ListOfProduct { get; set; } = new List<OrderItem>();
        public decimal TotalPrice => ListOfProduct.Sum(i => i.SubTotal);
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
