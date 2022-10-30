namespace EFCoreSample.Persistence.Oracle.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Persistence.Extensions;

public static class OracleContextExtension
{
    private const string ConnectionStringName = "OracleConnection";
    
    public static void AddCustomOracleContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseOracle(connectionString,
                oracleOptions => oracleOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
