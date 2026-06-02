using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{

    public record MaintenanceGenericDTO(
        [Required]
        int Id,
        string Comments,
        string Description,
        MaintenanceGenericStatus Status,
        DateTimeOffset StartedAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        DateTimeOffset EndedAt
    );

    public record MaintenanceOrderDTO(
        [Required]
        int Id,
        string Comments,
        string Description,
        MaintenanceGenericStatus Status,
        DateTimeOffset StartedAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        DateTimeOffset EndedAt,

        //Unique fields
        string OrderTitle
    ) : MaintenanceGenericDTO(
        Id,
        Comments,
        Description,
        Status,
        StartedAt,
        CreatedAt,
        UpdatedAt,
        EndedAt
    )
    {
        public static MaintenanceOrderDTO FromEntity(MaintenanceOrder order) => new(
            Id: order.Id,
            Comments: order.Comments,
            Description: order.Description,
            Status: order.Status,
            StartedAt: order.StartedAt,
            CreatedAt: order.CreatedAt,
            UpdatedAt: order.UpdatedAt,
            EndedAt: order.EndedAt,
            OrderTitle: order.OrderTitle
        );
    }

    public record MaintenanceTaskDTO(
        [Required]
        int Id,
        string Comments,
        string Description,
        MaintenanceGenericStatus Status,
        DateTimeOffset StartedAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        DateTimeOffset EndedAt,

        //Unique fields
        int MaintenanceOrderId,
        int AirplaneId,
        TaskType Type,
        double DurationMinutes
    ) : MaintenanceGenericDTO(
        Id,
        Comments,
        Description,
        Status,
        StartedAt,
        CreatedAt,
        UpdatedAt,
        EndedAt
    )
    {
        public static MaintenanceTaskDTO FromEntity(MaintenanceTask task) => new(
            Id: task.Id,
            Comments: task.Comments,
            Description: task.Description,
            Status: task.Status,
            StartedAt: task.StartedAt,
            CreatedAt: task.CreatedAt,
            UpdatedAt: task.UpdatedAt,
            EndedAt: task.EndedAt,
            MaintenanceOrderId: task.MaintenanceOrderId,
            AirplaneId: task.AirplaneId,
            Type: task.Type,
            DurationMinutes: task.Duration.TotalMinutes
        );

        public static MaintenanceTask FromDTO(CreateMaintenanceTaskDTO dto)
        {
            return new MaintenanceTask
            {
                Description = dto.Description,
                OrderId = dto.OrderId,
                AirplaneId = dto.AirplaneId,
                Type = dto.Type,
                Deadline = dto.Deadline,
                Comments = dto.Comments ?? "",
            };
        }
    }

    public record UpdateMaintenanceTaskDTO(
        string? Comments,
        string? Description,
        MaintenanceGenericStatus? Status,
        DateTimeOffset? StartedAt,
        DateTimeOffset? UpdatedAt,
        DateTimeOffset? EndedAt,

        //Unique fields
        TaskType? Type,
        TimeSpan? Duration,
        DateTimeOffset? Deadline
    );

    public record CreateMaintenanceTaskDTO(
        [Required] string Description,

        //Unique fields
        [Required] int OrderId,
        [Required] int AirplaneId,
        [Required] TaskType Type,
        [Required] DateTimeOffset Deadline,

        string? Comments
    );

    public record MaintenanceSiteDTO(
        [Required]
        int Id,
        MaintenanceSiteStatus Status,
        int? CurrentTaskId = null
    )

    {
        public static MaintenanceSiteDTO FromEntity(MaintenanceSite site) => new(
            Id: site.Id,
            Status: site.Status,
            CurrentTaskId: site.CurrentTaskId
        );
    }
}