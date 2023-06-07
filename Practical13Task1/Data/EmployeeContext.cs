using Microsoft.EntityFrameworkCore;
using Practical13Task1.Models;

namespace Practical13Task1.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { 
        
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
