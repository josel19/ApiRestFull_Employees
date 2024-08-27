using System;
using System.Collections.Generic;
using ApiRestFull_Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFull_Employees.Data;

public partial class ApiRestDBContext : DbContext
{
    public ApiRestDBContext()
    {
    }

    public ApiRestDBContext(DbContextOptions<ApiRestDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11EBEE1C5E");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
