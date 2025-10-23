using Jso.BookManagement.Application.DTOs;
using Jso.BookManagement.Application.Interfaces;
using Jso.BookManagement.Domain.Entities;
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

        public async Task<UserDto?> AddUserAsync(UserDto user)
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Password = user.Password
            };

            await _userRepository.AddAsync(entity);

            // Return the created user DTO (for confirmation)
            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password
            };
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

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }

        public Task<UserDto?> UpdateUserAync(Guid id, UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
