using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practical14Task1.Models;

public partial class MvcpracticalContext : DbContext
{ 
    public MvcpracticalContext(DbContextOptions<MvcpracticalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=SF-CPU-536\\SQLEXPRESS;Database=MVCPractical;Trusted_Connection=true;TrustServerCertificate=True;");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Employee>(entity =>
    //    {
    //        entity.ToTable("Employee");

    //        entity.Property(e => e.Dob)
    //            .HasColumnType("date")
    //            .HasColumnName("DOB");
    //        entity.Property(e => e.Name).HasMaxLength(50);
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
