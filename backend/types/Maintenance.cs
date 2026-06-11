namespace backend.types
{
    public class MaintenanceSite
    {
        public int Id { get; set; }

        public MaintenanceSiteStatus Status { get; set; }

        public int? CurrentTaskId { get; set; }
        public MaintenanceTask? CurrentTask { get; set; }
    }

    public interface IHasTimestamps
    {
        public DateTimeOffset? StartedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? EndedAt { get; set; }
    }

    public abstract class MaintenanceGeneric
    {
        public int Id { get; set; }
        public string Comments { get; set; } = "";
        public string Description { get; set; } = "";

        public MaintenanceGenericStatus Status { get; set; }
        public DateTimeOffset? StartedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? EndedAt { get; set; }
    }

    public class MaintenanceOrder : MaintenanceGeneric
    {
        public string OrderTitle { get; set; } = "";

        public List<MaintenanceTask> Tasks { get; set; } = [];
    }

    public class MaintenanceTask : MaintenanceGeneric
    {
        public int MaintenanceOrderId { get; set; }
        public MaintenanceOrder MaintenanceOrder { get; set; } = null!;

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; } = null!;

        public TaskType Type { get; set; }

        public TimeSpan Duration { get; set; }

        public List<Personnel> AssignedPersonnel { get; set; } = [];

        public List<TaskResourceRequirement> ResourceRequirements { get; set; } = [];

        public DateTimeOffset Deadline { get; set; }
    }

    public enum MaintenanceSiteStatus
    {
        Active,
        Inactive
    }

    public enum MaintenanceGenericStatus
    {
        In_Progress,
        Verification,
        Finished,
        Blocked
    }

    public enum TaskType
    {
        Maintenance1,
        Maintenance2,
        Maintenance3,
        Maintenance4,
    }
}