using backend.types;
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
            modelBuilder.Entity<Personnel>()
            .HasDiscriminator<UserRole>("Role")
            .HasValue<Technician>(UserRole.Technician)
            .HasValue<Operator>(UserRole.Operator)
            .HasValue<Supervisor>(UserRole.Supervisor);

            modelBuilder.Entity<ResourceGeneric>()
            .HasDiscriminator<ResourceType>("Type")
            .HasValue<Fuel>(ResourceType.Fuel)
            .HasValue<Ammunition>(ResourceType.Ammunition)
            .HasValue<Battery>(ResourceType.Battery);

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