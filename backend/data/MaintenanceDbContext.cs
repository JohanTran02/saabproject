using backend.types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend.data
{
    public class MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : DbContext(options)
    {

        public MaintenanceDbContext() : this(new DbContextOptions<MaintenanceDbContext>())
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
            ChangeTracker.Tracked += UpdateTimestamps;
        }

        public DbSet<Airplane> Airplanes => Set<Airplane>();
        public DbSet<MaintenanceSite> Sites => Set<MaintenanceSite>();
        public DbSet<MaintenanceOrder> Orders => Set<MaintenanceOrder>();
        public DbSet<MaintenanceTask> Tasks => Set<MaintenanceTask>();
        public DbSet<Personnel> Personnel => Set<Personnel>();
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<TaskResourceRequirement> ResourceRequirements => Set<TaskResourceRequirement>();

        private static void UpdateTimestamps(object? sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Modified:
                        entityWithTimestamps.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.CreatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
            .HasIndex(r => new { r.Name, r.Type })
            .IsUnique();

            modelBuilder.Entity<Resource>()
            .HasIndex(r => r.Sku)
            .IsUnique();

            modelBuilder.Entity<MaintenanceOrder>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<MaintenanceTask>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()");
        }
    }
}