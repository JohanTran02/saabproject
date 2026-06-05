using backend.types.DTO;


namespace backend.OrderItems
{
    public interface IOrderService
    {
        Task<List<MaintenanceOrderDTO>> GetAllAsync();
        Task<MaintenanceOrderDTO?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceOrderDTO incoming);
        Task<MaintenanceOrderDTO> CreateAsync(CreateMaintenanceOrderDTO incoming);
    }
}