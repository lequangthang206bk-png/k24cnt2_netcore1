using Microsoft.EntityFrameworkCore;
using LQThangShopdochoi.Models;

namespace LQThangShopdochoi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
                entity.Property(p => p.Price).HasPrecision(18, 2);
                entity.Property(p => p.Description).HasMaxLength(1000);
                entity.Property(p => p.ImageUrl).HasMaxLength(1000);
                entity.Property(p => p.Category).HasMaxLength(100).IsRequired();
            });
        }
    }
}
