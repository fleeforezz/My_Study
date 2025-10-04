using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarrantyManagement.DAL.Entities;

namespace WarrantyManagement.DAL.Repositoties
{
    public interface IUserRepository
    {
        Task<User> AddUser();
        Task<User> UpdateUser(Guid id);
        Task<bool> DeleteUser(Guid id);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUsers();
    }
}
