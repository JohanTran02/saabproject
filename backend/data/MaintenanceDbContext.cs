using backend.types;
using backend.utils;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
    public class MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : DbContext(options)
    {
        public DbSet<Airplane> Airplanes => Set<Airplane>();
        public DbSet<MaintenanceSite> Sites => Set<MaintenanceSite>();
        public DbSet<MaintenanceOrder> Orders => Set<MaintenanceOrder>();
        public DbSet<MaintenanceTask> Tasks => Set<MaintenanceTask>();
        public DbSet<Personnel> Personnel => Set<Personnel>();
        public DbSet<ResourceGeneric> Resources => Set<ResourceGeneric>();
        public DbSet<TaskResourceRequirement> ResourceRequirements => Set<TaskResourceRequirement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Personnel> personnel = [
                new Technician(),
                new Operator(),
                new Supervisor()
            ];

            modelBuilder.AutoMapByEnum<Personnel, UserRole>("Role", personnel);

            List<ResourceGeneric> resources = [
                new Fuel(),
                new Ammunition(),
                new Battery()
            ];

            modelBuilder.AutoMapByEnum<ResourceGeneric, ResourceType>("Type", resources);

            modelBuilder.Entity<ResourceGeneric>()
            .HasOne(r => r.Airplane)
            .WithMany(a => a.Resources)
            .HasForeignKey(r => r.AirplaneId);

            modelBuilder.Entity<ResourceGeneric>()
            .HasIndex(r => new { r.Name, r.Type })
            .IsUnique();

            modelBuilder.Entity<ResourceGeneric>()
            .HasIndex(r => r.Sku)
            .IsUnique();
        }
    }
}