using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Name> Names { get; set; } = null!;
    public virtual DbSet<Title> Titles { get; set; } = null!;
    public virtual DbSet<Rating> Ratings { get; set; } = null!;
    public virtual DbSet<Title> Works { get; set; } = null!;
    public virtual DbSet<Cast> Casts { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Name>(entity =>
        {
            entity.HasKey(e => e.Nconst)
                .HasName("PRIMARY");

            entity.ToTable("names");

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
        
        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("ratings");

            entity.HasIndex(e => e.Tconst, "tconst");

            entity.Property(e => e.Tconst)
                .HasMaxLength(11)
                .HasColumnName("tconst")
                .IsRequired();

            entity.Property(e => e.AverageRating)
                .HasPrecision(2)
                .IsRequired();
        });
        
        // Procedure Model
        // GetCastsByTconst
        modelBuilder.Entity<Cast>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.Nconst);
            entity.Property(e => e.PrimaryName);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

