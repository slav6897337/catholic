using System.Linq.Expressions;
using Catholic.Core.Helpers;
using Catholic.Domain;
using MongoDB.Driver;

namespace Catholic.Core.Repositories;

public abstract class MongoRepository<TObject> where TObject : Entity
{
    private const string connectionString = "MongoDbConnectionString";
    
    protected readonly IMongoCollection<TObject> collection;

    protected MongoRepository(string collectionName, string databaseName = "Catholic", bool createCollection = false)
    {
        var mongoDbConnectionString = Environment.GetEnvironmentVariable(connectionString);
        MongoClient client = new MongoClient(mongoDbConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseName);
        if (createCollection)
        {
            var collections = database.ListCollectionNames().ToList();
            if (collections.All(c => c != collectionName))
            {
                database.CreateCollection(collectionName);
            }
        }
        collection = database.GetCollection<TObject>(collectionName);
    }
    
    public async Task<List<TObject>> GetAllAsync(
        Expression<Func<TObject, bool>>? filter = null,
        Expression<Func<TObject, object>>? sortBy = null,
        bool ascending = true)
    {
        var items = await collection
            .Find(filter ?? (i => true))
            .Sort(SortBy(sortBy, ascending))
            .ToListAsync();
        return items;   
    }
    
    public async Task UpdateAsync(string id,  TObject entity) =>
        await collection.ReplaceOneAsync(i => i.Id == id, entity);
    
    public async Task<Paging<TObject>> GetPagingAsync(
        Paging paging,
        Expression<Func<TObject, bool>>? filter = null,
        Expression<Func<TObject, object>>? sortBy = null,
        bool ascending = true)
    {
        var count = await collection.CountDocumentsAsync(o => true);
        
        var items = await collection
            .Find(filter ?? (i => true))
            .Sort(SortBy(sortBy, ascending))
            .Skip(paging.Skip)
            .Limit(paging.Take)
            .ToListAsync();
        
        return paging.Result(items, (int)count);   
    }


    public async Task DeleteAsync(string id)
    {
        await collection.DeleteOneAsync(note => note.Id == id);
    }
    
    private SortDefinition<TObject> SortBy(Expression<Func<TObject, object>>? field = null, bool ascending = true)
    {
        var builder = Builders<TObject>.Sort;
        
        return ascending 
            ? builder.Ascending(field ?? (n => n.Date)) 
            : builder.Descending(field ?? (n => n.Date));
    }
}

public record UpdateField<TObject>(Expression<Func<TObject, object>> Field, object Value) where TObject : Entity;