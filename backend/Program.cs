using backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MaintenanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider);
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.Run();
