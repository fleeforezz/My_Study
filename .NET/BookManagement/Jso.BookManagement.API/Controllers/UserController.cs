using Jso.BookManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllProduct()
        {
            var users = await _userService.GetAllUserAsync();

            if (users  == null)
            {
                return Ok(users);
            }

            return NotFound();
        }
    }
}
