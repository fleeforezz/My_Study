using Jso.BookManagement.Domain.Entities;
using Jso.BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jso.BookManagement.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagementDbContext _dbContext;

        public UserRepository(BookManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> AddAsync(User user)
        {
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existUser == null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }

            return existUser;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            //var users = _dbContext.Users.ToList();
            //return await Task.FromResult(users);

            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> UpdateAync(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
