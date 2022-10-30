namespace EFCoreSample.Persistence.DbContexts;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

using EFCoreSample.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public DbSet<Sample> Samples { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
