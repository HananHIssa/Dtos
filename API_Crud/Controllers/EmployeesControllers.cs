using API_Crud.Data;
using API_Crud.DTOS.Employees;
using API_Crud.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControllers : ControllerBase
    {
        private ApplicationDbContext context;
        public EmployeesControllers(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var employee = context.Employees.ToList();
            var result = employee.Adapt<GetAllEmployee>();
            return Ok(result);
        }
        [HttpPost("Create")]

        public IActionResult Create (CreateEmployeecs emp)
        {
            var res = emp.Adapt<Employee>();
            context.Employees.Add(res);
            context.SaveChanges();
            return Ok("employee added succsesfully!!");
        }
    }
}
