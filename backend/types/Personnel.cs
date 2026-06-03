namespace backend.types
{
    public abstract class Personnel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public PersonnelStatus Status { get; set; } = PersonnelStatus.Inactive;

        public abstract UserRole Role { get; set; }

    }

    public class Technician : Personnel
    {
        public override UserRole Role { get; set; } = UserRole.Technician;

        public int? CurrentTaskId { get; set; }

        public MaintenanceTask? CurrentTask { get; set; }
    }

    public class Operator : Personnel
    {
        public override UserRole Role { get; set; } = UserRole.Operator;

        public int? CurrentOrderId { get; set; }

        public MaintenanceOrder? CurrentOrder { get; set; }
    }

    public class Supervisor : Personnel
    {
        public override UserRole Role { get; set; } = UserRole.Supervisor;

        public int? CurrentTaskId { get; set; }

        public MaintenanceTask? CurrentTask { get; set; }
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