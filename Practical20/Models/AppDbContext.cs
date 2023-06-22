﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Practical20.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
    }
}
