namespace EFCoreSample.Data.MySql.Extensions;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EFCoreSample.Data.DbContexts;

public static class MySqlContextExtension
{
    private const string ConnectionStringName = "MySqlConnection";
    
    public static void AddCustomMySqlContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var migrationAssemblyName = Assembly
            .GetExecutingAssembly().GetName().Name;
        
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySQL(connectionString,
                mySqlOptions => mySqlOptions
                    .MigrationsAssembly(migrationAssemblyName)));

        services.BuildServiceProvider()
            .GetService<ApplicationDbContext>()!
            .Database
            .Migrate();
    }
}
