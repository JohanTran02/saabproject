using backend.types;
using backend.types.DTO;

namespace backend.Resources
{
    public interface IResourceService
    {
        Task<List<ResourceDTO>> GetAllAsync();
        Task<ResourceDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateResourceDTO incoming);
        Task<ResourceDTO> CreateAsync(CreateResourceDTO incoming);
    }
}