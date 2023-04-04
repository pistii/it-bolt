using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ItBolt.Model.Entities;
using System.ComponentModel;

namespace ITBolt.API.Data
{
    public partial class ITBoltContext : DbContext
    {
        public ITBoltContext()
        {
        }

        public ITBoltContext(DbContextOptions<ITBoltContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalo> felhasznalo { get; set; }
        public virtual DbSet<Bolt> bolt { get; set; } = null!;
        public virtual DbSet<Eszkoz> eszkoz { get; set; }
        public virtual DbSet<Gyarto> gyarto { get; set; } = null!;
        public virtual DbSet<Kategoria> kategoria { get; set; } = null!;
        public virtual DbSet<Leltarieszkoz> leltarieszkoz { get; set; }
        public virtual DbSet<Raktar> raktar { get; set; } = null!;
        public virtual DbSet<Vasarlas> vasarlas { get; set; } = null!;
        public virtual DbSet<Vasarlo> vasarlo { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;database=it_bolt", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.20-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            /*
            //bolt
            modelBuilder.Entity<Bolt>(entity =>
            {
                entity.HasOne(d => d.raktar)
                    .WithMany(p => p.bolt)
                    .HasForeignKey(d => d.raktarID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bolt_ibfk_1");
                //leltarieszkoz - bolt

                entity.HasMany(d => d.leltarieszkoz)
                    .WithOne(p => p.bolt)
                    .HasPrincipalKey(d => d.boltID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leltarieszkoz_ibfk_2");
            });


            //eszköz
            modelBuilder.Entity<Eszkoz>(entity =>
            {
                entity.HasOne(d => d.gyarto)
                    .WithMany(p => p.eszkoz)
                    .HasForeignKey(d => d.eszkozID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eszkoz_ibfk_3");

                entity.HasOne(d => d.kategoria)
                    .WithMany(p => p.eszkoz)
                    .HasForeignKey(d => d.kategoriaID)
                    .HasConstraintName("eszkoz_ibfk_4");

            });

            //leltárieszköz
            modelBuilder.Entity<Leltarieszkoz>(entity =>
            {
                entity.HasOne(d => d.bolt)
                    .WithMany(p => p.leltarieszkoz)
                    .HasForeignKey(d => d.boltID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leltarieszkoz_ibfk_5");
            });

            //vasarlas
            modelBuilder.Entity<Vasarlas>(entity =>
            {
                entity.HasOne(d => d.vasarlo)
                    .WithMany(p => p.vasarlas)
                    .HasForeignKey(d => d.vasarloID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vasarlas_ibfk_5");
            });

            */
            
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bolt>(entity =>
            {
                entity.HasOne(d => d.raktar)
                    .WithMany(p => p.raktarak)
                    .HasForeignKey(d => d.raktarID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bolt_ibfk_1");
            });


            modelBuilder.Entity<Eszkoz>(entity =>
            {
                entity.HasOne(d => d.gyarto)
                    .WithMany(p => p.eszkoz)
                    .HasForeignKey(d => d.gyartoID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eszkoz_ibfk_2");
                
                entity.HasOne(d => d.kategoria)
                    .WithMany(p => p.eszkoz)
                    .HasForeignKey(d => d.kategoriaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eszkoz_ibfk_3");
            });

            modelBuilder.Entity<Leltarieszkoz>(entity =>
            {
                entity.HasKey(e => new { e.eszkozID, e.boltID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                //entity.HasOne(d => d.bolt)
                //    .WithMany(p => p.leltarieszkoz)
                //    .HasForeignKey(d => d.boltID)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("leltarieszkoz_ibfk_1");
            });

            modelBuilder.Entity<Vasarlas>(entity =>
            {
                entity.HasKey(e => new { e.vasarloID, e.rendelesID })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasOne(d => d.vasarlo)
                    .WithMany(p => p.vasarlas)
                    .HasForeignKey(d => d.vasarloID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vasarlas_ibfk_1");
            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
