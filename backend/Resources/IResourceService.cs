using backend.types;
using backend.types.DTO;

namespace backend.Resources
{
    public interface IResourceService
    {
        Task<List<ResourceGeneric>> GetAllAsync();
        Task<ResourceGeneric?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateResourceDTO incoming);
        Task<ResourceGeneric> CreateAsync(CreateResourceDTO incoming);
    }
}