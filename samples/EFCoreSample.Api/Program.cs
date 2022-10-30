using EFCoreSample.Api.Extensions;
using EFCoreSample.Data.DbContexts;
using EFCoreSample.Data.Sqlite.Extensions;
using EFCoreSample.Data.PostgreSql.Extensions;
using EFCoreSample.Data.SqlServer.Extensions;
using EFCoreSample.Data.MySql.Extensions;
using EFCoreSample.Data.Oracle.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Important: one project cannot contain multiple providers,
// the code below is just an example of how to initialize a context
// using different providers
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
