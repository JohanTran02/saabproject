using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Resources
{
    public class ResourceService(MaintenanceDbContext dbContext) : IResourceService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<ResourceGeneric>> GetAllAsync()
        {
            return await _db.Resources.ToListAsync();
        }

        public async Task<ResourceGeneric?> GetByIdAsync(int id)
        {
            return await _db.Resources.FindAsync(id)
                is ResourceGeneric resource
                ? resource
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

        public async Task<ResourceGeneric> CreateAsync(CreateResourceDTO dto)
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

            return entity;
        }
    }
}