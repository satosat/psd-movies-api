﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public partial class MoviesAPIContext : DbContext
    {
        public MoviesAPIContext()
        {
        }

        public MoviesAPIContext(DbContextOptions<MoviesAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Name> Names { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Name>(entity =>
            {
                entity.HasKey(e => e.Nconst)
                    .HasName("PRIMARY");

                entity.ToTable("names");

                entity.HasIndex(e => e.Nconst, "nameIndex")
                    .IsUnique();

                entity.Property(e => e.Nconst)
                    .HasMaxLength(11)
                    .HasColumnName("nconst")
                    .IsFixedLength();

                entity.Property(e => e.BirthYear)
                    .HasMaxLength(4)
                    .HasColumnName("birthYear")
                    .IsFixedLength();

                entity.Property(e => e.DeathYear)
                    .HasMaxLength(4)
                    .HasColumnName("deathYear");

                entity.Property(e => e.PrimaryName)
                    .HasMaxLength(255)
                    .HasColumnName("primaryName");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("PRIMARY");

                entity.ToTable("titles");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(11)
                    .HasColumnName("tconst");

                entity.Property(e => e.OriginalTitle)
                    .HasMaxLength(255)
                    .HasColumnName("originalTitle");

                entity.Property(e => e.PrimaryTitle)
                    .HasMaxLength(255)
                    .HasColumnName("primaryTitle");

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .HasColumnName("startYear")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("works");

                entity.HasIndex(e => e.Nconst, "nconst");

                entity.HasIndex(e => e.Tconst, "tconst");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(11)
                    .HasColumnName("nconst")
                    .IsFixedLength();

                entity.Property(e => e.Tconst)
                    .HasMaxLength(11)
                    .HasColumnName("tconst");

                entity.HasOne(d => d.NconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("works_ibfk_1");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("works_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}