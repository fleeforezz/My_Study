using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarrantyManagement.DAL.Entities;

namespace WarrantyManagement.BLL.Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(Guid id);
        Task<bool> DeleteUser(Guid id);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUsers();
    }
}
