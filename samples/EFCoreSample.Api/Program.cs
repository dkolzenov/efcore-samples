using EFCoreSample.Api.Extensions;
using EFCoreSample.Persistence.DbContexts;
using EFCoreSample.Persistence.Sqlite.Extensions;
using EFCoreSample.Persistence.PostgreSql.Extensions;
using EFCoreSample.Persistence.SqlServer.Extensions;
using EFCoreSample.Persistence.MySql.Extensions;
using EFCoreSample.Persistence.Oracle.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// En -> Important: one project cannot contain multiple providers,
// the code below is just an example of how to initialize a context
// using different providers
// Ru -> Важно: один проект не может содержать несколько поставщиков,
// приведенный ниже код является лишь примером того, как инициализировать контекст
// с использованием разных поставщиков
builder.Services.AddCustomSqliteContext<ApplicationDbContext>(builder.Configuration);
builder.Services.AddCustomPostgreSqlContext<ApplicationDbContext>(builder.Configuration);
builder.Services.AddCustomSqlServerContext<ApplicationDbContext>(builder.Configuration);
builder.Services.AddCustomMySqlContext<ApplicationDbContext>(builder.Configuration);
builder.Services.AddCustomOracleContext<ApplicationDbContext>(builder.Configuration);

builder.Services.AddCustomCorsPolicy(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomCorsPolicy();

app.UseAuthorization();

app.MapControllers();

app.Run();
