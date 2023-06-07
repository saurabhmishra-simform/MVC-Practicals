using Microsoft.EntityFrameworkCore;
using Practical13Task2.Models;

namespace Practical13Task2.Data
{
    public class EmployeeDesignationContext : DbContext
    {
        public EmployeeDesignationContext(DbContextOptions<EmployeeDesignationContext>options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}
