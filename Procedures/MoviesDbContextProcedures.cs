using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Procedures;

public partial class MoviesDbContextProcedures : DbContext
{
    public virtual DbSet<Work> Works { get; set; } = null!;
    public virtual DbSet<Cast> Casts { get; set; } = null!;

    public MoviesDbContextProcedures()
    {
    }

    public MoviesDbContextProcedures(DbContextOptions<MoviesDbContextProcedures> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Work result table structure
        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.Tconst);
            entity.Property(e => e.PrimaryTitle);
            entity.Property(e => e.OriginalTitle);
            entity.Property(e => e.StartYear);
        });

        // Cast result table structure
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