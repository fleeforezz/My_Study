using Jso.BookManagement.Application.DTOs;
using Jso.BookManagement.Application.Interfaces;
using Jso.BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jso.BookManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task AddUserAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password
            }).ToList();
        }

        public Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> UpdateUserAync(Guid id, UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
