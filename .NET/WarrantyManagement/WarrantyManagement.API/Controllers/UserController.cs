using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.BLL.Services;

namespace WarrantyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
