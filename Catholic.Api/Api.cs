using Catholic.Core.Services;

namespace Catholic.Api;

public static class Api
{
    public static void MapApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/daily-bible-quote", (BibleService bibleService) =>
            bibleService.GetBibleQuoteAsync());
    }
}