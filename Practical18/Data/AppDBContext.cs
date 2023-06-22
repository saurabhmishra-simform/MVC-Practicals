using Microsoft.EntityFrameworkCore;
using Practical18.Models;

namespace Practical18.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> Students { get; set; }
    }
}
