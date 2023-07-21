using Catholic.Core.Repositories;
using Catholic.Domain;

namespace Catholic.Core.Services;

public class NewsService : MongoRepository<News>
{
    public NewsService() : base("News")
    {
    }
    
    
    public async Task<News> AddNewsAsync(News news)
    {
        ArgumentException.ThrowIfNullOrEmpty(news.Title);
        ArgumentException.ThrowIfNullOrEmpty(news.Description);
        
        await collection.InsertOneAsync(news);
          
        return news;   
    }
    
    public async Task<News> UpdateNewsAsync(string id, News news)
    {
        ArgumentException.ThrowIfNullOrEmpty(news.Title);
        ArgumentException.ThrowIfNullOrEmpty(news.Description);
        
        await UpdateAsync(id, news);
          
        return news;   
    }

}