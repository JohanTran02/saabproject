using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.types
{
    public class Personnel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public PersonnelStatus Status { get; set; } = PersonnelStatus.Inactive;

        public UserRole Role { get; set; }

        public int? CurrentTaskId { get; set; }

        [ForeignKey(nameof(CurrentTaskId))]
        public MaintenanceTask? CurrentTask { get; set; }

        public int? CurrentOrderId { get; set; }

        [ForeignKey(nameof(CurrentOrderId))]
        public MaintenanceOrder? CurrentOrder { get; set; }
    }

    public enum UserRole
    {
        Technician,
        Supervisor,
        Operator
    }

    public enum PersonnelStatus
    {
        Active,
        Inactive
    }

}