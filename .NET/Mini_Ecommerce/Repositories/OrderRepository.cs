using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    //public class OrderRepository : IRepository<Order>
    //{
    //    private readonly FileDatabase<Order> _db;

    //    public OrderRepository(string filepath)
    //    {
    //        _db = new FileDatabase<Order>(filepath);
    //    }

    //    public void Add(Order order)
    //    {
    //        var orders = _db.Load().ToList();

    //        orders.Add(order);
    //        _db.SaveChanges(orders);
    //    }

    //    public void Delete(Guid id)
    //    {
    //        var orders = _db.Load().ToList();
    //        orders.RemoveAll(o => o.Id == id);
    //        _db.SaveChanges(orders);
    //    }

    //    public IEnumerable<Order> GetAll()
    //    {
    //        return _db.Load();
    //    }

    //    public Order GetById(Guid id)
    //    {
    //        return _db.Load().FirstOrDefault(o => o.Id == id);
    //    }

    //    public void Update(Order order)
    //    {
    //        var orders = _db.Load().ToList();
    //        var index = orders.FindIndex(o => o.Id == order.Id);

    //        orders.Insert(index, order);
    //        _db.SaveChanges(orders);
    //    }
    //}
}
