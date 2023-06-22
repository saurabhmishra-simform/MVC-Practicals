using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practical19MVC.Models;

namespace Practical19MVC.Data
{
    public class AppDBContext: IdentityDbContext<Users>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
