namespace EFCoreSample.Data.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    
    using  EFCoreSample.Data.Entities;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<WordSet> WordSets { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
