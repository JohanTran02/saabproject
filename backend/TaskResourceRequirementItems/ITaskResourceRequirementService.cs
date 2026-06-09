using backend.types.DTO;

namespace backend.TaskResourceRequirementItems
{
    public interface ITaskResourceRequirementService
    {
        Task<List<TaskResourceRequirementDTO>> GetAllAsyncById(int taskId);
        Task<TaskResourceRequirementDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateTaskResourceRequirementDTO incoming);
        Task<TaskResourceRequirementDTO> CreateAsync(CreateTaskResourceRequirementDTO incoming);
    }
}