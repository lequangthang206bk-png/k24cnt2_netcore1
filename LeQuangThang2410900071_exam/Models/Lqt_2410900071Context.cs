using Microsoft.EntityFrameworkCore;

namespace LeQuangThang2410900071_exam.Models;

public class Lqt_2410900071Context : DbContext
{
    public Lqt_2410900071Context(DbContextOptions<Lqt_2410900071Context> options) : base(options)
    {
    }

    public DbSet<LqtEmployee> LqtEmployees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LqtEmployee>(entity =>
        {
            entity.ToTable("LqtEmployee");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LqtName).HasMaxLength(100);
            entity.Property(e => e.LqtGender).HasMaxLength(20);
            entity.Property(e => e.LqtEmail).HasMaxLength(150);
            entity.Property(e => e.LqtPhone).HasMaxLength(20);
            entity.Property(e => e.LqtActive).HasDefaultValue(true);
        });
    }
}
