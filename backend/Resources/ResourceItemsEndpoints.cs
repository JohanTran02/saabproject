using backend.types;
using backend.types.DTO;

namespace backend.Resources
{
    public static class ResourceItemsEndpoints
    {
        public static void RegisterResourceItemsEndpoints(this WebApplication app)
        {
            var resources = app.MapGroup("/resources");

            resources.MapGet("/", GetAllResources);
            resources.MapGet("/{id}", GetResourceById);
            resources.MapDelete("/{id}", DeleteResourceById);
            resources.MapPatch("/{id}", UpdateResourceById);
            resources.MapPost("/", CreateResource);
        }

        static async Task<IResult> GetAllResources(IResourceService resourceService)
        {
            List<ResourceGeneric> resources = await resourceService.GetAllAsync();

            return TypedResults.Ok(resources.Select(ResourceDTO.FromEntity));
        }

        static async Task<IResult> GetResourceById(int id, IResourceService resourceService)
        {
            return await resourceService.GetByIdAsync(id)
                is ResourceGeneric resource
                ? TypedResults.Ok(ResourceDTO.FromEntity(resource))
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeleteResourceById(int id, IResourceService resourceService)
        {
            if (await resourceService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> UpdateResourceById(int id, UpdateResourceDTO incoming, IResourceService resourceService)
        {
            if (await resourceService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> CreateResource(CreateResourceDTO incoming, IResourceService resourceService)
        {
            try
            {
                ResourceGeneric resource = await resourceService.CreateAsync(incoming);

                return TypedResults.Created($"Created resource/{resource.Id}", ResourceDTO.FromEntity(resource));
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }
        }
    }
}