using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuantumQuery.DAL.SQLite.Models;

namespace QuantumQuery.DAL.SQLite.Context;

public partial class QuantumQueryDbContext : DbContext
{
    public QuantumQueryDbContext(DbContextOptions<QuantumQueryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Element> Elements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
