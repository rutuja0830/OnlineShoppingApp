using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Models;

namespace OnlineShoppingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.DiscountPercentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 60000, DiscountPercentage = 10 },
                new Product { Id = 2, Name = "Mobile", Description = "Smart Phone", Price = 20000, DiscountPercentage = 5 },
                new Product { Id = 3, Name = "Headphones", Description = "Noise Cancelling", Price = 5000, DiscountPercentage = 15 }
            );
        }
    }
}