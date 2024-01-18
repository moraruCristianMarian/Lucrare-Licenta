using LicentaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LicentaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MenuProduct> MenuProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Composite primary key
            modelBuilder.Entity<MenuProduct>()
                .HasKey(mp => new { mp.ProductId, mp.RestaurantId });


            // Foreign keys to Restaurant and Product
            modelBuilder.Entity<MenuProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(mp => mp.MenuProducts)
                .HasForeignKey(mp => mp.ProductId);

            modelBuilder.Entity<MenuProduct>()
                .HasOne(mp => mp.Restaurant)
                .WithMany(mp => mp.MenuProducts)
                .HasForeignKey(mp => mp.RestaurantId);
        }
    }
}
