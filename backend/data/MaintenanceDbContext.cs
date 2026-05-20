using backend.types;
using Microsoft.EntityFrameworkCore;

class MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : DbContext(options)
{
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    public DbSet<MaintenanceSite> Sites => Set<MaintenanceSite>();
    public DbSet<MaintenanceOrder> Orders => Set<MaintenanceOrder>();
    public DbSet<MaintenanceTask> Tasks => Set<MaintenanceTask>();
    public DbSet<Personnel> Personnel => Set<Personnel>();
    public DbSet<ResourceGeneric> ResourceGeneric => Set<ResourceGeneric>();
}