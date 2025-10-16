using Jso.BookManagement.Domain.Entities;
using Jso.BookManagement.Domain.Repositories;
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

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = _dbContext.Users.ToList();
            return await Task.FromResult(users);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAync(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
