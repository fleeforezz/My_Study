using Jso.BookManagement.Application.DTOs;
using Jso.BookManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jso.BookManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await _userService.GetAllUserAsync();

            if (users  == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(UserDto user)
        {
            var newUser = await _userService.AddUserAsync(user);

            if (newUser == null)
            {
                return NotFound();
            }

            return Ok(newUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
                return NotFound();

            return Ok(user);
        }
    }
}
