using Microsoft.EntityFrameworkCore;
using ECommerceApp.Domain.Models;
using ECommerceApp.Domain.ValueObjects;

namespace ECommerceApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.OwnsOne(p => p.Price, price =>
                {
                    price.Property(p => p.Amount).HasColumnName("PriceAmount");
                    price.Property(p => p.Currency).HasColumnName("PriceCurrency");
                });
            });
        }
    }
}