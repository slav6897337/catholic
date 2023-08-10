using Catholic.Core.Repositories;
using Catholic.Domain;

namespace Catholic.Core.Services;

public class HolyMassService : MongoRepository<HolyMass>
{
    public HolyMassService() : base("HolyMass")
    {
    }

    public async Task<HolyMass> AddPageAsync(HolyMass holyMass)
    {
        await collection.InsertOneAsync(holyMass);
          
        return holyMass;   
    }
    
    public async Task<HolyMass> UpdatePageAsync(string id, HolyMass holyMass)
    {
        await UpdateAsync(id, holyMass);
          
        return holyMass;   
    }
}