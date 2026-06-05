using backend.types.DTO;

namespace backend.SiteItems
{
    public interface ISiteService
    {
        Task<List<MaintenanceSiteDTO>> GetAllAsync();
        Task<MaintenanceSiteDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceSiteDTO incoming);
        Task<MaintenanceSiteDTO> CreateAsync(CreateMaintenanceSiteDTO incoming);
    }
}