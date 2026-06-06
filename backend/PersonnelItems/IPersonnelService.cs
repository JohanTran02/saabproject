using backend.types.DTO;

namespace backend.PersonnelItems
{
    public interface IPersonnelService
    {
        Task<List<PersonnelDTO>> GetAllAsync();
        Task<PersonnelDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdatePersonnelDTO incoming);
        Task<bool> AssignTaskAsync(int id, int? taskid);
        Task<bool> AssignOrderAsync(int id, int? orderId);
        Task<PersonnelDTO> CreateAsync(CreatePersonnelDTO incoming);
    }
}