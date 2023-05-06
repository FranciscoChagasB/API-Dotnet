﻿using API_Dotnet6.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace API_Dotnet6.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Produtcts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}