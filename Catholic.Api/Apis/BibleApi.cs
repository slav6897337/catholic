using Catholic.Core.Services;

namespace Catholic.Api.Apis;

public static class BibleApi
{
    public static void MapBibleApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/daily-bible-quote", (BibleService bibleService) =>
            bibleService.GetBibleQuoteAsync());
    }
}