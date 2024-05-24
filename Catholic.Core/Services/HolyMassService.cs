using Catholic.Core.Repositories;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class HolyMassService : MongoRepository<HolyMass>
{
    public HolyMassService(IMemoryCache cache) : base("HolyMass", cache)
    {
    }

    public async Task<HolyMass> AddPageAsync(HolyMass holyMass)
    {
        await collection.InsertOneAsync(holyMass);
        
        UpdateCacheInBackground();
          
        return holyMass;   
    }
    
    public async Task<HolyMass> UpdatePageAsync(string id, HolyMass holyMass)
    {
        holyMass.Date = DateTime.UtcNow;
        await UpdateAsync(id, holyMass);
        
        return holyMass;   
    }
}