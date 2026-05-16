namespace backend.types
{
    public class MaintenanceSite
    {
        public int Id { get; set; }
        public List<int>? QueueTaskList { get; set; }

        public enum MaintenanceStatus
        {
            Active,
            Inactive
        }

        public MaintenanceStatus Status { get; set; }

        public int? NextTaskId { get; set; }

        public List<int>? AssignedPersonnelIds { get; set; }

        public int? CurrentOrderId { get; set; }

        public int? CurrentTaskId { get; set; }
    }

    public class MaintenanceGeneric
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public string? Description { get; set; }

        public List<ResourceGeneric>? ReqResources { get; set; }

        public enum MaintenanceStatus
        {
            In_Progress,
            Verification,
            Finished,
            Blocked
        }

        public MaintenanceStatus Status { get; set; }

        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
    }

    public class MaintenanceOrder : MaintenanceGeneric
    {
        public List<int>? MaintenanceTaskIds { get; set; }

        public string? OrderTitle { get; set; }

        public int? AirplaneId { get; set; }

        public DateTimeOffset? Deadline { get; set; }

        public List<int>? AssignedPersonnelIds { get; set; }

    }

    public class MaintenanceTask : MaintenanceGeneric
    {
        public int? OrderId { get; set; }

        public TaskType Type { get; set; }

        public TimeSpan Duration { get; set; }

    }

    public enum TaskType
    {
        Maintenance1,
        Mainteannce2,
        Maintenance3,
        Maintenance4,
    }
}