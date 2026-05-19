namespace backend.types
{
    public class MaintenanceSite
    {
        public int Id { get; set; }
        public List<int> QueueTaskListIds { get; set; } = [];

        public MaintenanceSiteStatus Status { get; set; }

        public int NextTaskId { get; set; }

        public List<int> AssignedPersonnelIds { get; set; } = [];

        public int CurrentOrderId { get; set; }

        public int CurrentTaskId { get; set; }
    }

    public abstract class MaintenanceGeneric
    {
        public int Id { get; set; }
        public string Comments { get; set; } = "";
        public string Description { get; set; } = "";

        public List<int> ReqResourceIds { get; set; } = [];

        public MaintenanceGenericStatus Status { get; set; }

        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
    }

    public class MaintenanceOrder : MaintenanceGeneric
    {
        public List<int> TaskIds { get; set; } = [];

        public string OrderTitle { get; set; } = "";

        public int AirplaneId { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public List<int> AssignedPersonnelIds { get; set; } = [];

    }

    public class MaintenanceTask : MaintenanceGeneric
    {
        public int OrderId { get; set; }

        public TaskType Type { get; set; }

        public TimeSpan Duration { get; set; }

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