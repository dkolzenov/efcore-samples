namespace EFCoreSample.Persistence.SqlServer.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Persistence.Extensions;

public static class SqlServerContextExtension
{
    private const string ConnectionStringName = "SqlServerConnection";
    
    public static void AddCustomSqlServerContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseSqlServer(connectionString,
                sqlServerOptions => sqlServerOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
