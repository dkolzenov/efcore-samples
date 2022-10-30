namespace EFCoreSample.Data.MySql.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.Extensions;

public static class MySqlContextExtension
{
    private const string ConnectionStringName = "MySqlConnection";
    
    public static void AddCustomMySqlContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TContext : DbContext
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);
        
        services.AddCustomDbContext<TContext>(
            options => options.UseMySQL(connectionString,
                mySqlOptions => mySqlOptions
                    .MigrationsAssembly(migrationAssemblyName)));
    }
}
