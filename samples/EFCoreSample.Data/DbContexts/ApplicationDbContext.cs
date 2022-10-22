namespace EFCoreSample.Data.DbContexts
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using EFCoreSample.Data.Entities;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<WordSet> WordSets { get; set; } = null!;

        public DbSet<Alphabet> Alphabets { get; set; } = null!;

        public DbSet<Direction> Directions { get; set; } = null!;

        public DbSet<WordOnGrid> WordsOnGrid { get; set; } = null!;

        public DbSet<CharacterOnGrid> CharactersOnGrid { get; set; } = null!;

        public DbSet<DataGrid> DataGrids { get; set; } = null!;

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
}
