using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Procedures;

public partial class MoviesDbContextProcedures : DbContext
{
    public virtual DbSet<Work> Works { get; set; } = null!;

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
    }
}