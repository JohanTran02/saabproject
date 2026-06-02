using backend.types.DTO;

namespace backend.TaskItems
{
    public interface ITaskService
    {
        Task<List<MaintenanceTaskDTO>> GetAllAsync();
        Task<MaintenanceTaskDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceTaskDTO incoming);
        Task<MaintenanceTaskDTO> CreateAsync(CreateMaintenanceTaskDTO incoming);
    }
}