
using backend.types.DTO;

namespace backend.TaskItems
{
    public static class TaskItemsEndpoints
    {
        public static void RegisterTaskItemsEndpoints(this WebApplication app)
        {
            var tasks = app.MapGroup("/tasks")
                           .WithTags("Tasks");

            tasks.MapGet("/", GetAllTasks);
            tasks.MapGet("/{id}", GetTaskById);
            tasks.MapDelete("/{id}", DeleteTaskById);
            tasks.MapPatch("/{id}", UpdateTaskById);
            tasks.MapPost("/", CreateTask);
        }

        static async Task<IResult> GetAllTasks(ITaskService taskService)
        {
            List<MaintenanceTaskDTO> tasks = await taskService.GetAllAsync();

            return TypedResults.Ok(tasks);
        }

        static async Task<IResult> GetTaskById(int id, ITaskService taskService)
        {
            return await taskService.GetByIdAsync(id)
                is MaintenanceTaskDTO task
                ? TypedResults.Ok(task)
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeleteTaskById(int id, ITaskService taskService)
        {
            if (await taskService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> UpdateTaskById(int id, UpdateMaintenanceTaskDTO incoming, ITaskService taskService)
        {
            if (await taskService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> CreateTask(CreateMaintenanceTaskDTO incoming, ITaskService taskService)
        {
            MaintenanceTaskDTO task = await taskService.CreateAsync(incoming);

            return TypedResults.Created($"Created task/{task.Id}", task);
        }
    }
}