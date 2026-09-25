
using Microsoft.EntityFrameworkCore;

namespace LQthangLesson10._1.Models;

public partial class Lqtk24cnt2Lesson10Context : DbContext
{
    public Lqtk24cnt2Lesson10Context(
        DbContextOptions<Lqtk24cnt2Lesson10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<LqtMember> LqtMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LqtMember>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_LqtMember");

            entity.ToTable("LqtMember");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.LqtUserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.LqtPassword)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LqtFullName)
                .HasMaxLength(50);

            entity.Property(e => e.LqtEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LqtPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.LqtStatus)
                .HasColumnType("bit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
