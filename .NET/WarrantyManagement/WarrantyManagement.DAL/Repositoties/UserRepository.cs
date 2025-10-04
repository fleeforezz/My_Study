using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarrantyManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarrantyManagement.DAL.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private readonly WarrantyDbContext _dbContext;

        public UserRepository(WarrantyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
