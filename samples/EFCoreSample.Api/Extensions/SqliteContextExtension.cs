namespace EFCoreSample.Api.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using EFCoreSample.Data;

    public static class SqliteContextExtension
    {
        private const string ConnectionStringName = "SqliteConnection";

        public static void AddCustomSqliteContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString(ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlite(connectionString));

            services.BuildServiceProvider()
                .GetService<ApplicationDbContext>()!
                .Database
                .Migrate();
        }
    }
}

