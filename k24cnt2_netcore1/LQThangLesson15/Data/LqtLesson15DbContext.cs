using LQThangLesson15.Models;
using Microsoft.EntityFrameworkCore;

namespace LQThangLesson15.Data;

public class LqtLesson15DbContext : DbContext
{
    public LqtLesson15DbContext(DbContextOptions<LqtLesson15DbContext> options) : base(options)
    {
    }

    public DbSet<LqtProduct> Products => Set<LqtProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LqtProduct>(entity =>
        {
            entity.ToTable("LqtProduct");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Category).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
            entity.Property(x => x.ImageUrl).HasMaxLength(300);
            entity.Property(x => x.Description).HasMaxLength(500);
        });
    }
}
