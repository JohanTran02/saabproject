using backend.types.DTO;

namespace backend.PersonnelItems
{
    public static class PersonnelItemsEndpoints
    {
        public static void RegisterPersonnelItemsEndpoints(this WebApplication app)
        {
            var personnel = app.MapGroup("/personnel");

            personnel.MapGet("/", GetAllPersonnel);
            personnel.MapGet("/{id}", GetPersonnelById);
            personnel.MapDelete("/{id}", DeletePersonnelById);
            personnel.MapPatch("/{id}", UpdatePersonnelById);
            personnel.MapPatch("/{id}/task", AssignTaskById);
            personnel.MapPatch("/{id}/order", AssignOrderById);
            personnel.MapPost("/", CreatePersonnel);
        }

        static async Task<IResult> GetAllPersonnel(IPersonnelService personnelService)
        {
            List<PersonnelDTO> personnel = await personnelService.GetAllAsync();

            return TypedResults.Ok(personnel);
        }

        static async Task<IResult> GetPersonnelById(int id, IPersonnelService personnelService)
        {
            return await personnelService.GetByIdAsync(id)
                is PersonnelDTO personnel
                ? TypedResults.Ok(personnel)
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeletePersonnelById(int id, IPersonnelService personnelService)
        {
            if (await personnelService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> UpdatePersonnelById(int id, UpdatePersonnelDTO incoming, IPersonnelService personnelService)
        {
            if (await personnelService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> AssignTaskById(int id, int? taskId, IPersonnelService personnelService)
        {
            try
            {
                if (await personnelService.AssignTaskAsync(id, taskId) is true) return TypedResults.NoContent();

                return TypedResults.NotFound();
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }
        static async Task<IResult> AssignOrderById(int id, int? orderId, IPersonnelService personnelService)
        {
            try
            {
                if (await personnelService.AssignOrderAsync(id, orderId) is true) return TypedResults.NoContent();

                return TypedResults.NotFound();
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }

        static async Task<IResult> CreatePersonnel(CreatePersonnelDTO incoming, IPersonnelService personnelService)
        {
            PersonnelDTO personnel = await personnelService.CreateAsync(incoming);

            return TypedResults.Created($"Created personnel/{personnel.Id}", personnel);
        }
    }
}