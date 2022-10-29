namespace EFCoreSample.Data.PostgreSql.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.DbContexts;

public static class PostgreSqlContextExtension
{
    private const string ConnectionStringName = "PostgreSqlConnection";

    public static void AddCustomPostgreSqlContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(connectionString,
                postgresOptions => postgresOptions
                    .MigrationsAssembly(migrationAssemblyName)));

        services.BuildServiceProvider()
            .GetService<ApplicationDbContext>()!
            .Database
            .Migrate();
    }
}
