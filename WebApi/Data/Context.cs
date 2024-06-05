using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock{ get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(p => p.Stocks)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.IdProduct);
                  
            modelBuilder.Entity<TypeProduct>()
            .HasMany(tp => tp.Products)
            .WithOne(p => p.TypeProduct)
            .HasForeignKey(p => p.IdTypeProduct);
           
        }
    }
}