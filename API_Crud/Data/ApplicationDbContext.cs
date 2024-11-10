using API_Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <Department> Departments { get; set; }
    }
}
