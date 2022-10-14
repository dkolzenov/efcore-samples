namespace EFCoreSample.Api.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using EFCoreSample.Data.DbContexts;

    public static class PostgreSqlContextExtension
    {
        private const string ConnectionStringName = "PostgreSqlConnection";

        private const string MigrationAssemblyName = "EFCoreSample.Data.PostgreSql";

        public static void AddCustomPostgreSqlContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString(ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString,
                postgresOptions => postgresOptions
                    .MigrationsAssembly(MigrationAssemblyName)));

            services.BuildServiceProvider()
                .GetService<ApplicationDbContext>()!
                .Database
                .Migrate();
        }
    }
}

