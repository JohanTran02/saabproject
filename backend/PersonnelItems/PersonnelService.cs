using backend.data;
using backend.types;
using backend.types.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.PersonnelItems
{
    public class PersonnelService(MaintenanceDbContext dbContext) : IPersonnelService
    {
        private readonly MaintenanceDbContext _db = dbContext;

        public async Task<List<PersonnelDTO>> GetAllAsync()
        {
            List<Personnel> personnel = await _db.Personnel.ToListAsync();
            List<PersonnelDTO> dTOs = [.. personnel.Select(PersonnelDTO.MapToDto)];

            return dTOs;
        }

        public async Task<PersonnelDTO?> GetByIdAsync(int id)
        {
            return await _db.Personnel.FindAsync(id)
                is Personnel personnel
                ? PersonnelDTO.MapToDto(personnel)
                : null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Personnel? personnel = await _db.Personnel.FindAsync(id);

            if (personnel is null) return false;

            _db.Personnel.Remove(personnel);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdatePersonnelDTO incoming)
        {
            Personnel? personnel = await _db.Personnel.FindAsync(id);

            if (personnel is null) return false;

            foreach (var property in typeof(UpdatePersonnelDTO).GetProperties())
            {
                var incomingValue = property.GetValue(incoming);

                if (incomingValue != null)
                {
                    var targetProperty = _db.Entry(personnel).Property(property.Name);
                    targetProperty.CurrentValue = incomingValue;
                }
            }

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignTaskAsync(int id, int? taskId)
        {
            Personnel? worker = await _db.Personnel
                .Where(p => p.Id == id && (p is Technician || p is Supervisor))
                .FirstOrDefaultAsync();

            if (worker is null)
            {
                throw new InvalidOperationException("Personnel not found or cannot be assigned to tasks.");
            }

            if (taskId.HasValue)
            {
                if (!await _db.Tasks.AnyAsync(t => t.Id == taskId.Value))
                {
                    throw new InvalidOperationException("Task doesn't exist.");
                }
            }

            if (worker is Technician tech)
            {
                tech.CurrentTaskId = taskId;
            }
            else if (worker is Supervisor super)
            {
                super.CurrentTaskId = taskId;
            }

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignOrderAsync(int id, int? orderId)
        {
            Operator? op = await _db.Personnel
                .OfType<Operator>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (op is null)
            {
                throw new InvalidOperationException("Personnel not found or cannot be assigned to orders.");
            }

            if (orderId.HasValue)
            {
                if (!await _db.Orders.AnyAsync(o => o.Id == orderId))
                {
                    throw new InvalidOperationException("Order doesn't exist.");
                }
            }

            op.CurrentOrderId = orderId;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<PersonnelDTO> CreateAsync(CreatePersonnelDTO dto)
        {
            var entity = PersonnelDTO.MapFromDto(dto);
            _db.Personnel.Add(entity);
            await _db.SaveChangesAsync();

            var taskDTO = PersonnelDTO.MapToDto(entity);

            return taskDTO;
        }

    }
}