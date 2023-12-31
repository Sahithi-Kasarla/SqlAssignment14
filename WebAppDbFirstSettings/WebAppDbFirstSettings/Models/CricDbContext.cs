using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDbFirstSettings.Models
{
    public partial class CricDbContext : DbContext
    {
        public CricDbContext()
        {
        }

        public CricDbContext(DbContextOptions<CricDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-MONMK0F;database=CricDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamName)
                    .HasConstraintName("FK__Player__TeamName__3A81B327");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.HasIndex(e => e.TeamName, "UQ__Team__4E21CAACB0E3C540")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TeamName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
