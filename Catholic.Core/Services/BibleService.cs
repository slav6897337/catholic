using Catholic.Core.Clients;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class BibleService
{
    private readonly IMemoryCache memoryCache;
    private readonly BibleClient bibleClient;
    private const string quoteCacheKey = "BibleQuote";

    public BibleService(IMemoryCache memoryCache, BibleClient bibleClient)
    {
        this.memoryCache = memoryCache;
        this.bibleClient = bibleClient;
    }

    public async Task<BibleQuote> GetBibleQuoteAsync()
    {
        var quote = await memoryCache.GetOrCreateAsync(quoteCacheKey, async entry =>
        {
            entry.AbsoluteExpiration = DateTime.UtcNow.AddDays(1).Date;
            return await bibleClient.GetBibleQuoteAsync();
        });


        return quote;
    }
}