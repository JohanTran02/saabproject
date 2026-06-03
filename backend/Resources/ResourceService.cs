using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Resources
{
    public class ResourceService(MaintenanceDbContext dbContext) : IResourceService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<ResourceDTO>> GetAllAsync()
        {
            List<ResourceGeneric> resources = await _db.Resources.ToListAsync();
            List<ResourceDTO> dTOs = [.. resources.Select(ResourceDTO.FromEntity)];

            return dTOs;
        }

        public async Task<ResourceDTO?> GetByIdAsync(int id)
        {
            return await _db.Resources.FindAsync(id)
                is ResourceGeneric resource
                ? ResourceDTO.FromEntity(resource)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            ResourceGeneric? resource = await _db.Resources.FindAsync(id);

            if (resource is null) return false;

            _db.Resources.Remove(resource);

            await _db.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateByIdAsync(int id, UpdateResourceDTO incoming)
        {
            ResourceGeneric? resource = await _db.Resources.FindAsync(id);

            if (resource is null) return false;

            _db.Entry(resource).CurrentValues.SetValues(incoming);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<ResourceDTO> CreateAsync(CreateResourceDTO dto)
        {
            bool exists = await _db.Resources
                .OfType<ResourceGeneric>()
                .AnyAsync(r => r.Name == dto.Name && r.Type == dto.Type);

            if (exists)
            {
                throw new InvalidOperationException($"A {dto.Type} resource with the name '{dto.Name}' already exists.");
            }

            var entity = ResourceDTO.FromDTO(dto);
            _db.Resources.Add(entity);
            await _db.SaveChangesAsync();

            var resourceDTO = ResourceDTO.FromEntity(entity);

            return resourceDTO;
        }
    }
}