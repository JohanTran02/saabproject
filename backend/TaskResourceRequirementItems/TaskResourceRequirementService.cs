using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.TaskResourceRequirementItems
{
    public class TaskResourceRequirementService(MaintenanceDbContext dbContext) : ITaskResourceRequirementService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<TaskResourceRequirementDTO>> GetAllAsyncById(int taskId)
        {
            if (!await _db.Tasks.AnyAsync(t => t.Id == taskId)) throw new InvalidOperationException("Task doesn't exist.");

            List<TaskResourceRequirement> taskResourceRequirements = await _db.ResourceRequirements
                                                                              .Where(rr => rr.TaskId == taskId)
                                                                              .Include(resource => resource.Buffer)
                                                                              .ToListAsync();

            List<TaskResourceRequirementDTO> dTOs = [.. taskResourceRequirements.Select(TaskResourceRequirementDTO.FromEntity)];

            return dTOs;
        }

        public async Task<TaskResourceRequirementDTO?> GetByIdAsync(int id)
        {
            return await _db.ResourceRequirements
                            .Include(rr => rr.Buffer)
                            .FirstOrDefaultAsync(rr => rr.Id == id)
                is TaskResourceRequirement resourceRequirement
                ? TaskResourceRequirementDTO.FromEntity(resourceRequirement)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            TaskResourceRequirement? resourceRequirement = await _db.ResourceRequirements.FindAsync(id);

            if (resourceRequirement is null) return false;

            _db.ResourceRequirements.Remove(resourceRequirement);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateTaskResourceRequirementDTO incoming)
        {
            TaskResourceRequirement? resourceRequirement = await _db.ResourceRequirements.FindAsync(id);

            if (resourceRequirement is null) return false;

            if (!await _db.Tasks.AnyAsync(t => t.Id == resourceRequirement.TaskId)) throw new InvalidOperationException("Task doesn't exist.");
            if (!await _db.Resources.AnyAsync(r => r.Id == resourceRequirement.ResourceId)) throw new InvalidOperationException("Resource doesn't exist.");

            foreach (var property in typeof(UpdateTaskResourceRequirementDTO).GetProperties())
            {
                var incomingValue = property.GetValue(incoming);

                if (incomingValue != null)
                {
                    var targetProperty = _db.Entry(resourceRequirement).Property(property.Name);
                    targetProperty.CurrentValue = incomingValue;
                }
            }

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<TaskResourceRequirementDTO> CreateAsync(CreateTaskResourceRequirementDTO dto)
        {
            if (!await _db.Tasks.AnyAsync(t => t.Id == dto.TaskId)) throw new InvalidOperationException("Task doesn't exist.");
            if (!await _db.Resources.AnyAsync(r => r.Id == dto.ResourceId)) throw new InvalidOperationException("Resource doesn't exist.");

            var entity = TaskResourceRequirementDTO.FromDTO(dto);
            _db.ResourceRequirements.Add(entity);
            await _db.SaveChangesAsync();

            var taskDTO = TaskResourceRequirementDTO.FromEntity(entity);

            return taskDTO;
        }
    }
}