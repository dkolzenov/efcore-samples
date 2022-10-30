namespace EFCoreSample.Data.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbContextExtension
{
    public static void AddCustomDbContext<TContext>(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsAction) where TContext : DbContext
    {
        services.AddDbContext<TContext>(optionsAction);

        services.BuildServiceProvider()
            .GetService<TContext>()!
            .Database
            .Migrate();
    }
}
