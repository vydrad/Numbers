
using Microsoft.EntityFrameworkCore;
using Numerologia.Models;

namespace Numerologia.Data;

public sealed class NumerologiaDbContext : DbContext
{
    public NumerologiaDbContext(DbContextOptions<NumerologiaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Interpretation> Interpretations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var interpretation = modelBuilder.Entity<Interpretation>();

        interpretation.ToTable("Interpretations");
        interpretation.HasKey(x => x.Id);

        interpretation.Property(x => x.Number)
            .IsRequired();

        interpretation.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);

        interpretation.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        interpretation.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(4000);

        interpretation.HasIndex(x => new { x.Number, x.Type });
    }
}