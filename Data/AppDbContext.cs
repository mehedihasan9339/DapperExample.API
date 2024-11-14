using DapperExample.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperExample.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", CategoryId = 1 },
                new Product { Id = 3, Name = "T-shirt", CategoryId = 2 },
                new Product { Id = 4, Name = "Jeans", CategoryId = 2 },
                new Product { Id = 5, Name = "C# Programming Book", CategoryId = 3 },
                new Product { Id = 6, Name = "JavaScript Book", CategoryId = 3 }
            );
        }
    }
}
