using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Docker.Core.Entities;

namespace Docker.Infrastructure.Data
{
    public partial class DockerContext : DbContext
    {
        public DockerContext()
        {
        }

        public DockerContext(DbContextOptions<DockerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CodeCity)
                    .HasName("PK__City__6038EA13F9749844");

                entity.ToTable("City");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.CodeSeller)
                    .HasName("PK__Seller__107DB57D8D065A1A");

                entity.ToTable("Seller");

                entity.Property(e => e.DocumentSeller)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastNameSeller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameSeller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeCitySellerNavigation)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.CodeCitySeller)
                    .HasConstraintName("Fkcliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
