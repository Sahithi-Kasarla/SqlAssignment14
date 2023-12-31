using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment14.Models
{
    public partial class Assignment14Context : DbContext
    {
        public Assignment14Context()
        {
        }

        public Assignment14Context(DbContextOptions<Assignment14Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-MONMK0F;database=Assignment14;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__6A1C8AFA051BBF75");

                entity.ToTable("Category");

                entity.Property(e => e.CatId).ValueGeneratedNever();

                entity.Property(e => e.CatName).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Course__C1F8DC392D9D7B39");

                entity.ToTable("Course");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Cfee).HasColumnName("CFee");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");

                entity.Property(e => e.CstartDate)
                    .HasColumnType("date")
                    .HasColumnName("CStartDate");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Course__CatId__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
