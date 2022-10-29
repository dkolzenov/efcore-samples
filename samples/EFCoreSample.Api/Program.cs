using EFCoreSample.Api.Extensions;
using EFCoreSample.Data.Sqlite.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Order is important when adding new migrations
//builder.Services.AddCustomPostgreSqlContext(builder.Configuration);
builder.Services.AddCustomSqliteContext(builder.Configuration);
builder.Services.AddCustomCorsPolicy(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomCorsPolicy();

app.UseAuthorization();

app.MapControllers();

app.Run();
