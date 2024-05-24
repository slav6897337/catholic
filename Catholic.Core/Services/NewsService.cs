using Catholic.Core.Repositories;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class NewsService : MongoRepository<News>
{
    public NewsService(IMemoryCache cache) : base("News", cache)
    {
    }
    
    
    public async Task<News> AddNewsAsync(News news)
    {
        ArgumentException.ThrowIfNullOrEmpty(news.Title);
        
        await collection.InsertOneAsync(news);
        
        UpdateCacheInBackground();
          
        return news;   
    }
    
    public async Task<News> UpdateNewsAsync(string id, News news)
    {
        ArgumentException.ThrowIfNullOrEmpty(news.Title);
        
        news.Date = DateTime.UtcNow;
        
        await UpdateAsync(id, news);
          
        return news;   
    }

}