using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(T entity);
    }
}
