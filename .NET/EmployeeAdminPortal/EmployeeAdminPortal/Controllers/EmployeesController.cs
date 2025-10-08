using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EmployeeAdminPortal.Controllers
{
    // Localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.Employees.ToList();

            return Ok(employees);
        }
    }
}
