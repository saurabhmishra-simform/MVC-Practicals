using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practical10Task3.Models;

public class SqlpracticalContext : DbContext
{
    public SqlpracticalContext(DbContextOptions<SqlpracticalContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}
