namespace EFCoreSample.Persistence.MsAccess.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Persistence.Extensions;

public static class MsAccessContextExtension
{
    private const string ConnectionStringName = "MsAccessConnection";
    
    public static void AddCustomMsAccessContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseJet(connectionString,
                jetOptions => jetOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
