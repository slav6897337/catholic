using Catholic.Api.Filters;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class PagesApi
{
    public static void MapPagesApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/pages-list", (PagesService pagesService) =>
            pagesService.ListPagesAsync());
            
        endpoints.MapGet("/api/pages/{uri}", (PagesService pagesService, string uri) =>
            pagesService.GetPageAsync(uri));
        
        endpoints.MapPost("/api/pages", (PagesService pagesService, Page page) =>
            pagesService.AddPageAsync(page)).AdminAuthorization();
        
        endpoints.MapPut("/api/pages/{id}", (PagesService pagesService, string id, Page page) =>
            pagesService.UpdatePageAsync(id, page)).AdminAuthorization();
        
        endpoints.MapDelete("/api/pages/{id}", (PagesService pagesService, string id) =>
            pagesService.DeleteAsync(id)).AdminAuthorization();
    }
}