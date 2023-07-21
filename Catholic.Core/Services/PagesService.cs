using Catholic.Core.Repositories;
using Catholic.Domain;
using MongoDB.Driver;

namespace Catholic.Core.Services;

public class PagesService : MongoRepository<Page>
{
    public PagesService() : base("Pages")
    {
    }
    
    public async Task<Page> GetPageAsync(string uri)
    {
        var page = await collection
            .Find(i => i.UrlSegment == uri)
            .FirstOrDefaultAsync();
        
        return page;
    }

    public async Task<List<string>> ListPagesAsync()
    {
        var pages = await collection
            .Find(i => true)
            .Project(i => i.UrlSegment)
            .ToListAsync();

        
        return pages?.Where(p => !string.IsNullOrWhiteSpace(p)).ToList() ?? new List<string>();
    }

    public async Task<Page> AddPageAsync(Page page)
    {
        ArgumentException.ThrowIfNullOrEmpty(page.Title);
        ArgumentException.ThrowIfNullOrEmpty(page.UrlSegment);
        ArgumentException.ThrowIfNullOrEmpty(page.Body);
        
        var pages = await ListPagesAsync();
        
        if (pages.Contains(page.UrlSegment))
        {
            throw new Exception($"Page with url segment {page.UrlSegment} already exists");
        }
        
        await collection.InsertOneAsync(page);
          
        return page;   
    }
    
    public async Task<Page> UpdatePageAsync(string id, Page page)
    {
        ArgumentException.ThrowIfNullOrEmpty(page.Title);
        ArgumentException.ThrowIfNullOrEmpty(page.UrlSegment);
        ArgumentException.ThrowIfNullOrEmpty(page.Body);
        
        await UpdateAsync(id, page);
          
        return page;   
    }
}