using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.TaskItems
{
    public class TaskService(MaintenanceDbContext dbContext) : ITaskService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<MaintenanceTaskDTO>> GetAllAsync()
        {
            List<MaintenanceTask> tasks = await _db.Tasks.Include(t => t.AssignedPersonnel).ToListAsync();
            List<MaintenanceTaskDTO> dTOs = [.. tasks.Select(MaintenanceTaskDTO.FromEntity)];

            return dTOs;
        }

        public async Task<MaintenanceTaskDTO?> GetByIdAsync(int id)
        {
            return await _db.Tasks.FindAsync(id)
                is MaintenanceTask task
                ? MaintenanceTaskDTO.FromEntity(task)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            MaintenanceTask? task = await _db.Tasks.FindAsync(id);

            if (task is null) return false;

            _db.Tasks.Remove(task);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceTaskDTO incoming)
        {

            MaintenanceTask? task = await _db.Tasks.FindAsync(id);

            if (task is null) return false;

            foreach (var property in typeof(UpdateMaintenanceTaskDTO).GetProperties())
            {
                var incomingValue = property.GetValue(incoming);

                if (incomingValue != null)
                {
                    var targetProperty = _db.Entry(task).Property(property.Name);
                    targetProperty.CurrentValue = incomingValue;
                }
            }

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<MaintenanceTaskDTO> CreateAsync(CreateMaintenanceTaskDTO dto)
        {
            if (!await _db.Tasks.AnyAsync(t => t.AirplaneId == dto.AirplaneId))
                throw new InvalidOperationException($"Airplane doesn't exist.");

            if (!await _db.Tasks.AnyAsync(t => t.MaintenanceOrderId == dto.MaintenanceOrderId))
                throw new InvalidOperationException($"Maintenance Order doesn't exist.");

            var entity = MaintenanceTaskDTO.FromDTO(dto);
            _db.Tasks.Add(entity);
            await _db.SaveChangesAsync();

            var taskDTO = MaintenanceTaskDTO.FromEntity(entity);

            return taskDTO;
        }
    }
}