using FnxTest.Models.Responses;

namespace FnxTest.Routes
{
    public static class RepositoriesRoutes
    {
        public static void MapRepositories(this IEndpointRouteBuilder app)
        {
            var repositoriesGroup = app.MapGroup("api/repositories/");
            repositoriesGroup.MapGet("search", async (string query, IConfiguration config, IRepositoriesService repositoriesService) =>
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Results.BadRequest("Query is required");
                }
                var repositories = await repositoriesService.GetRepositories(query);

                return Results.Ok(repositories);
            })
            .RequireAuthorization();
        }
    }

}
