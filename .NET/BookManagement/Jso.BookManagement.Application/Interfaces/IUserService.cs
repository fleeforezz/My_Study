using Jso.BookManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jso.BookManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(UserDto user);
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task<UserDto?> UpdateUserAync(Guid id, UserDto user);
        Task DeleteUserAsync(Guid id);
    }
}
