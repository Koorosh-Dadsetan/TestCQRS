using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestCQRS.Data.Models;

namespace TestCQRS.Data.Context;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<ChildTable> ChildTables { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ImageTable> ImageTables { get; set; }

    public virtual DbSet<ParentTable> ParentTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChildTable>(entity =>
        {
            entity.ToTable("ChildTable");

            entity.Property(e => e.ComponentName).HasMaxLength(50);

            entity.HasOne(d => d.Parent).WithMany(p => p.ChildTables)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChildTable_ParentTable");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ImageTable>(entity =>
        {
            entity.ToTable("ImageTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
        });

        modelBuilder.Entity<ParentTable>(entity =>
        {
            entity.ToTable("ParentTable");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
