using Catholic.Api.Filters;
using Catholic.Core.Helpers;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class NewsApi
{
    public static void MapNewsApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/news/all", (NewsService newsService) =>
            newsService.GetAllAsync(sortBy: n => n.Date, ascending: false));
        
        endpoints.MapGet("/api/news", (NewsService newsService, [AsParameters] RequestQuery request) =>
            newsService.GetPagingAsync(request.Paging(), request.HolyMassOnly is true ? f => f.IsChurchNews : null));
        
        endpoints.MapPost("/api/news", (NewsService newsService, News news) =>
            newsService.AddNewsAsync(news)).AdminAuthorization();
        
        endpoints.MapPut("/api/news/{id}", (NewsService newsService, string id, News news) =>
            newsService.UpdateNewsAsync(id, news)).AdminAuthorization();
        
        endpoints.MapDelete("/api/news/{id}", (NewsService newsService, string id) =>
            newsService.DeleteAsync(id)).AdminAuthorization();
    }
}