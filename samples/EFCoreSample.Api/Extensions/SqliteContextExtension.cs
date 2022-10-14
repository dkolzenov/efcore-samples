namespace EFCoreSample.Api.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using EFCoreSample.Data.DbContexts;

    public static class SqliteContextExtension
    {
        private const string ConnectionStringName = "SqliteConnection";

        private const string MigrationAssemblyName = "EFCoreSample.Data.Sqlite";

        public static void AddCustomSqliteContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString(ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(connectionString,
                sqliteOptions => sqliteOptions
                    .MigrationsAssembly(MigrationAssemblyName)));

            services.BuildServiceProvider()
                .GetService<ApplicationDbContext>()!
                .Database
                .Migrate();
        }
    }
}

