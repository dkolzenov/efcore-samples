namespace EFCoreSample.Persistence.Sqlite.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Persistence.Extensions;

public static class SqliteContextExtension
{
    private const string ConnectionStringName = "SqliteConnection";
    
    public static void AddCustomSqliteContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseSqlite(connectionString,
                sqliteOptions => sqliteOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
