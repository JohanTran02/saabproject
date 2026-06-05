using System.Text.Json.Serialization;
using backend;
using backend.data;
using backend.OrderItems;
using backend.Resources;
using backend.TaskItems;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<MaintenanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "SAABprojectAPI";
    config.Title = "SAABprojectAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "SAABprojectAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });

    using var scope = app.Services.CreateScope();
    await SeedData.Seed(scope.ServiceProvider);
}

app.RegisterTaskItemsEndpoints();
app.RegisterOrderItemsEndpoints();
app.RegisterResourceItemsEndpoints();
app.UseHttpsRedirection();

app.Run();
