namespace EFCoreSample.Data.SqlServer.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.DbContexts;

public static class SqlServerContextExtension
{
    private const string ConnectionStringName = "SqlServerConnection";
    
    public static void AddCustomSqlServerContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString,
                sqlServerOptions => sqlServerOptions
                    .MigrationsAssembly(migrationAssemblyName)));

        services.BuildServiceProvider()
            .GetService<ApplicationDbContext>()!
            .Database
            .Migrate();
    }
}
