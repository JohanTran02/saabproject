using backend.types.DTO;

namespace backend.SiteItems
{
    public static class SiteItemsEndpoints
    {
        public static void RegisterSiteItemsEndpoints(this WebApplication app)
        {
            var sites = app.MapGroup("/sites");

            sites.MapGet("/", GetAllSites);
            sites.MapGet("/{id}", GetSiteById);
            sites.MapDelete("/{id}", DeleteSiteById);
            sites.MapPatch("/{id}", UpdateSiteById);
            sites.MapPost("/", CreateSite);
        }
        static async Task<IResult> GetAllSites(ISiteService siteService)
        {
            List<MaintenanceSiteDTO> sites = await siteService.GetAllAsync();

            return TypedResults.Ok(sites);
        }

        static async Task<IResult> GetSiteById(int id, ISiteService siteService)
        {
            return await siteService.GetByIdAsync(id)
                is MaintenanceSiteDTO site
                ? TypedResults.Ok(site)
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeleteSiteById(int id, ISiteService siteService)
        {
            try
            {
                if (await siteService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

                return TypedResults.NotFound();
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }

        }

        static async Task<IResult> UpdateSiteById(int id, UpdateMaintenanceSiteDTO incoming, ISiteService siteService)
        {
            if (await siteService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> CreateSite(CreateMaintenanceSiteDTO incoming, ISiteService siteService)
        {
            MaintenanceSiteDTO site = await siteService.CreateAsync(incoming);

            return TypedResults.Created($"Created site/{site.Id}", site);
        }
    }
}