using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.SiteItems
{
    public class SiteService(MaintenanceDbContext dbContext) : ISiteService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<MaintenanceSiteDTO>> GetAllAsync()
        {
            List<MaintenanceSite> sites = await _db.Sites.ToListAsync();
            List<MaintenanceSiteDTO> dTOs = [.. sites.Select(MaintenanceSiteDTO.FromEntity)];

            return dTOs;
        }

        public async Task<MaintenanceSiteDTO?> GetByIdAsync(int id)
        {
            return await _db.Sites.FindAsync(id)
                is MaintenanceSite site
                ? MaintenanceSiteDTO.FromEntity(site)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            MaintenanceSite? site = await _db.Sites.FindAsync(id);

            if (site is null) return false;

            _db.Sites.Remove(site);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceSiteDTO incoming)
        {
            MaintenanceSite? site = await _db.Sites.FindAsync(id);

            if (site is null) return false;

            foreach (var property in typeof(UpdateMaintenanceSiteDTO).GetProperties())
            {
                var incomingValue = property.GetValue(incoming);

                if (incomingValue != null)
                {
                    var targetProperty = _db.Entry(site).Property(property.Name);
                    targetProperty.CurrentValue = incomingValue;
                }
            }

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<MaintenanceSiteDTO> CreateAsync(CreateMaintenanceSiteDTO dto)
        {
            var entity = MaintenanceSiteDTO.FromDTO(dto);
            _db.Sites.Add(entity);
            await _db.SaveChangesAsync();

            var taskDTO = MaintenanceSiteDTO.FromEntity(entity);

            return taskDTO;
        }
    }
}