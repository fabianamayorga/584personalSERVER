using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class ClothingBrandContext : DbContext
{
    public ClothingBrandContext()
    {
    }

    public ClothingBrandContext(DbContextOptions<ClothingBrandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClothingBrand> ClothingBrands { get; set; }

    public virtual DbSet<ClothingItem> ClothingItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=clothingBrand");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClothingItem>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Store).WithMany(p => p.ClothingItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clothingItems_clothingBrand1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
