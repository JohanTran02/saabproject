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
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<TaskResourceRequirement> ResourceRequirements => Set<TaskResourceRequirement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
            .HasIndex(r => new { r.Name, r.Type })
            .IsUnique();

            modelBuilder.Entity<Resource>()
            .HasIndex(r => r.Sku)
            .IsUnique();
        }
    }
}