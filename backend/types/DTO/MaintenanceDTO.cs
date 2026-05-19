using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{

    public record MaintenanceGenericDTO(
        [Required]
        int Id,
        string Comments,
        string Description,
        IReadOnlyList<int> ReqResourceIds,
        MaintenanceGenericStatus Status,
        DateTimeOffset StartedAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        DateTimeOffset EndedAt
    );

    public record MaintenanceOrderDTO : MaintenanceGenericDTO
    {
        public MaintenanceOrderDTO(MaintenanceGenericDTO baseData) : base(baseData) { }

        public IReadOnlyList<int> TaskIds { get; init; } = [];
        public IReadOnlyList<int> AssignedPersonnelIds { get; init; } = [];
        public DateTimeOffset Deadline { get; init; }
        public string OrderTitle { get; init; } = "";

        public static MaintenanceOrderDTO FromEntity(MaintenanceOrder order)
        {
            MaintenanceGenericDTO baseGeneric = new(
                order.Id,
                order.Comments,
                order.Description,
                [.. order.ReqResourceIds],
                order.Status,
                order.StartedAt,
                order.CreatedAt,
                order.UpdatedAt,
                order.EndedAt
            );

            return new MaintenanceOrderDTO(baseGeneric) with
            {
                TaskIds = [.. order.TaskIds],
                AssignedPersonnelIds = [.. order.AssignedPersonnelIds],
                Deadline = order.Deadline,
                OrderTitle = order.OrderTitle
            };
        }
    }

    public record MaintenanceTaskDTO : MaintenanceGenericDTO
    {
        public MaintenanceTaskDTO(MaintenanceGenericDTO baseData) : base(baseData) { }

    }

    // public record MaintenanceTaskDTO(
    //     [Required]
    //     int Id,
    //     string Comments,
    //     string Description,
    //     IReadOnlyList<int> ReqResourceIds,
    //     MaintenanceStatusGeneric Status,
    //     DateTimeOffset StartedAt,
    //     DateTimeOffset CreatedAt,
    //     DateTimeOffset UpdatedAt,
    //     DateTimeOffset EndedAt,
    //     //Unique fields
    //     int OrderId,
    //     string Type,
    //     double DurationMinutes
    // ) : MaintenanceGenericDTO(
    //     Id,
    //     Comments,
    //     Description,
    //     ReqResourceIds,
    //     Status,
    //     StartedAt,
    //     CreatedAt,
    //     UpdatedAt,
    //     EndedAt
    // )
    // {
    //     public static MaintenanceTaskDTO FromEntity(MaintenanceTask task) => new(
    //         Id: task.Id,
    //         Comments: task.Comments,
    //         Description: task.Description,
    //         ReqResourceIds: [.. task.ReqResourceIds],
    //         Status: task.Status,
    //         StartedAt: task.StartedAt,
    //         CreatedAt: task.CreatedAt,
    //         UpdatedAt: task.UpdatedAt,
    //         EndedAt: task.EndedAt,
    //         OrderId: task.OrderId,
    //         Type: task.Type.ToString(),
    //         DurationMinutes: task.Duration.TotalMinutes
    //     );
    // }

    public record MaintenanceSiteDTO(
        [Required]
        int Id,
        MaintenanceSiteStatus Status,
        IReadOnlyList<int> QueueTaskList,
        int NextTaskId,
        IReadOnlyList<int> AssignedPersonnelIds,
        int CurrentOrderId,
        int CurrentTaskId
    )

    {
        public static MaintenanceSiteDTO FromEntity(MaintenanceSite site) => new(
            Id: site.Id,
            Status: site.Status,
            QueueTaskList: [.. site.QueueTaskListIds],
            NextTaskId: site.NextTaskId,
            AssignedPersonnelIds: [.. site.AssignedPersonnelIds],
            CurrentOrderId: site.CurrentOrderId,
            CurrentTaskId: site.CurrentTaskId
        );
    }
}