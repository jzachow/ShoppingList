using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingListDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingListDAL
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(p =>
            {
                p.HasKey(_ => _.Id);

                p.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(30);

                p.Property(_ => _.Price)
                .IsRequired();
            });

            modelBuilder.Entity<Products>().HasData(
                    new Products { Id = 1, Name = "GTFO", Price = 27.99M },
                    new Products { Id = 2, Name = "Among Us", Price = 4.99M },
                    new Products { Id = 3, Name = "Phasmophobia", Price = 13.99M },
                    new Products { Id = 4, Name = "Hades", Price = 24.99M }
                );
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=Inventory;Trusted_Connection=true";
            var builder = new DbContextOptionsBuilder<InventoryContext>();

            builder.UseSqlServer(connectionString);

            return new InventoryContext(builder.Options);
        }
    }
}
