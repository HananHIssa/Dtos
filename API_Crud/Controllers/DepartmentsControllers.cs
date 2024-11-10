using API_Crud.Data;
using API_Crud.DTOS;
using API_Crud.DTOS.Department;
using API_Crud.DTOS.Employees;
using API_Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsControllers : ControllerBase
    {
        private ApplicationDbContext context;
        public DepartmentsControllers(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var department = context.Departments.Select(
                x => new GetAllDepartment()
                {
                    Name = x.Name,
                }
                ) ;
            return Ok(department);
        }
        [HttpPost("Create")]

        public IActionResult Create(CreateDeparment dep)
        {
            Department department = new Department()
            {
                Name = dep.Name,
            };
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok("department added succsesfully!!");
        }
    }
}
