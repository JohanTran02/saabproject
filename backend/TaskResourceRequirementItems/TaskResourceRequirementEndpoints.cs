using backend.types.DTO;

namespace backend.TaskResourceRequirementItems
{
    public static class TaskResourceRequirementEndpoints
    {
        public static void RegisterTaskResourceRequirementEndpoints(this WebApplication app)
        {
            var resourceRequirements = app.MapGroup("/requirements")
                                          .WithTags("Task Resource Requirements");

            resourceRequirements.MapGet("/{taskId}/all", GetAllTaskResourceRequirements);
            resourceRequirements.MapGet("/{id}", GetTaskResourceRequirementById);
            resourceRequirements.MapDelete("/{id}", DeleteResourceRequirementById);
            resourceRequirements.MapPatch("/{id}", UpdateResourceRequirementById);
            resourceRequirements.MapPost("/", CreateResourceRequirement);
        }

        static async Task<IResult> GetAllTaskResourceRequirements(int taskId, ITaskResourceRequirementService requirementService)
        {
            try
            {
                List<TaskResourceRequirementDTO> resourceRequirements = await requirementService.GetAllAsyncById(taskId);

                return TypedResults.Ok(resourceRequirements);
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }

        static async Task<IResult> GetTaskResourceRequirementById(int id, ITaskResourceRequirementService requirementService)
        {
            return await requirementService.GetByIdAsync(id)
                is TaskResourceRequirementDTO resourceRequirement
                ? TypedResults.Ok(resourceRequirement)
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeleteResourceRequirementById(int id, ITaskResourceRequirementService requirementService)
        {
            if (await requirementService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();

        }

        static async Task<IResult> UpdateResourceRequirementById(int id, UpdateTaskResourceRequirementDTO incoming, ITaskResourceRequirementService requirementService)
        {
            try
            {
                if (await requirementService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

                return TypedResults.NotFound();
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }

        static async Task<IResult> CreateResourceRequirement(CreateTaskResourceRequirementDTO incoming, ITaskResourceRequirementService requirementService)
        {
            try
            {
                TaskResourceRequirementDTO resourceRequirement = await requirementService.CreateAsync(incoming);

                return TypedResults.Created($"Created order/{resourceRequirement.Id}", resourceRequirement);
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }
    }
}