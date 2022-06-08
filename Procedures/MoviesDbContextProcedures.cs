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
        modelBuilder.Entity<Work>(e =>
        {
            e.HasNoKey();
            e.Property(e => e.Tconst);
            e.Property(e => e.PrimaryTitle);
            e.Property(e => e.OriginalTitle);
            e.Property(e => e.StartYear);
        });

        modelBuilder.Entity<Cast>(e =>
        {
            e.HasNoKey();
            e.Property(e => e.Nconst);
            e.Property(e => e.PrimaryName);
        });
        
        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}