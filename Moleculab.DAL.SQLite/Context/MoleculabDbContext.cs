using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moleculab.DAL.SQLite.Models;

namespace Moleculab.DAL.SQLite.Context;

public partial class MoleculabDbContext : DbContext
{
    public MoleculabDbContext(DbContextOptions<MoleculabDbContext> options)
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
