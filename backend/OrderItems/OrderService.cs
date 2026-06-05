using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.OrderItems
{
    public class OrderService(MaintenanceDbContext dbContext) : IOrderService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<MaintenanceOrderDTO>> GetAllAsync()
        {
            List<MaintenanceOrder> orders = await _db.Orders.ToListAsync();
            List<MaintenanceOrderDTO> dTOs = [.. orders.Select(MaintenanceOrderDTO.FromEntity)];

            return dTOs;
        }

        public async Task<MaintenanceOrderDTO?> GetByIdAsync(int id)
        {
            return await _db.Orders.FindAsync(id)
                is MaintenanceOrder order
                ? MaintenanceOrderDTO.FromEntity(order)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            MaintenanceOrder? order = await _db.Orders.FindAsync(id);

            if (order is null) return false;

            _db.Orders.Remove(order);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateMaintenanceOrderDTO incoming)
        {
            MaintenanceOrder? order = await _db.Orders.FindAsync(id);

            if (order is null) return false;

            if (order.Tasks.Count <= 0)
            {
                throw new InvalidOperationException($"Can't remove {order.Id} with assigned tasks.");
            }

            foreach (var property in typeof(UpdateMaintenanceOrderDTO).GetProperties())
            {
                var incomingValue = property.GetValue(incoming);

                if (incomingValue != null)
                {
                    var targetProperty = _db.Entry(order).Property(property.Name);
                    targetProperty.CurrentValue = incomingValue;
                }
            }

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<MaintenanceOrderDTO> CreateAsync(CreateMaintenanceOrderDTO dto)
        {
            var entity = MaintenanceOrderDTO.FromDTO(dto);
            _db.Orders.Add(entity);
            await _db.SaveChangesAsync();

            var taskDTO = MaintenanceOrderDTO.FromEntity(entity);

            return taskDTO;
        }
    }
}