namespace EFCoreSample.Data.Sqlite.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.DbContexts;

public static class SqliteContextExtension
{
    private const string ConnectionStringName = "SqliteConnection";
    
    public static void AddCustomSqliteContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlite(connectionString,
                sqliteOptions => sqliteOptions
                    .MigrationsAssembly(migrationAssemblyName)));

        services.BuildServiceProvider()
            .GetService<ApplicationDbContext>()!
            .Database
            .Migrate();
    }
}
