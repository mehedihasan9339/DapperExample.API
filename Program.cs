using System.Data;
using DapperExample.API.Dapper;
using DapperExample.API.Data;
using DapperExample.API.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDapper, DapperRepo>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "DapperExample API",
        Version = "v1",
        Description = "A sample API demonstrating Dapper and Swagger UI customization",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DapperExample API v1");
        c.RoutePrefix = string.Empty;

        c.InjectStylesheet("/swagger-ui/swagger-custom.css");
    });
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
