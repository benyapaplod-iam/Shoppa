using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shoppa.Data.Models;

public partial class EcommerceDbContext : DbContext
{
    private readonly string? connectionString;

    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public EcommerceDbContext(
        DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                connectionString ??
                "Host=localhost;Port=5432;Database=ecommerce_db;Username=postgres;Password=password"
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId)
                .HasName("orders_pkey");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.OrderitemId)
                .HasName("orderitems_pkey");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.Orderitems)
                .HasConstraintName("fk_order");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Orderitems)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId)
                .HasName("products_pkey");

            entity.Property(e => e.Stock)
                .HasDefaultValue(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(
        ModelBuilder modelBuilder);
}