using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practical17.Models;

namespace Practical17.Data
{
    public class AppDBContext : IdentityDbContext<Users>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
