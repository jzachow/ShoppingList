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
