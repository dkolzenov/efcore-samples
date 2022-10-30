namespace EFCoreSample.Data.PostgreSql.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.Extensions;

public static class PostgreSqlContextExtension
{
    private const string ConnectionStringName = "PostgreSqlConnection";
    
    public static void AddCustomPostgreSqlContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseNpgsql(connectionString,
                npgsqlOptions => npgsqlOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
