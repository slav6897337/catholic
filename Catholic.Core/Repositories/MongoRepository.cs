using System.Linq.Expressions;
using Catholic.Core.Helpers;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;

namespace Catholic.Core.Repositories;

public abstract class MongoRepository<TObject> where TObject : Entity
{
    protected readonly IMemoryCache? cache;
    private const string connectionString = "MongoDbConnectionString";
    private readonly string key;

    protected readonly IMongoCollection<TObject> collection;

    protected MongoRepository(string collectionName, IMemoryCache cache = null, string databaseName = "Catholic",
        bool createCollection = false)
    {
        this.cache = cache;
        this.key = collectionName;
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

    public async Task<List<TObject>?> GetAllAsync(
        Expression<Func<TObject, bool>>? filter = null,
        Expression<Func<TObject, object>>? sortBy = null,
        bool ascending = true)
    {
        if (cache == null)
        {
            return await GetAsync(filter, sortBy, ascending);
        }

        return await cache.GetOrCreateAsync(key, async entry => await GetAsync(filter, sortBy, ascending));
    }

    private async Task<List<TObject>> GetAsync(
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

    public async Task UpdateAsync(string id, TObject entity)
    {
        await collection.ReplaceOneAsync(i => i.Id == id, entity);
        UpdateCacheInBackground();
    }

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

        return paging.Result(items, (int) count);
    }


    public async Task DeleteAsync(string id)
    {
        await collection.DeleteOneAsync(note => note.Id == id);
        UpdateCacheInBackground();
    }

    private SortDefinition<TObject> SortBy(Expression<Func<TObject, object>>? field = null, bool ascending = true)
    {
        var builder = Builders<TObject>.Sort;

        return ascending
            ? builder.Ascending(field ?? (n => n.Date))
            : builder.Descending(field ?? (n => n.Date));
    }

    protected void UpdateCacheInBackground()
    {
        if (cache == null) return;
        cache.Remove(key);
#pragma warning disable CS4014
        cache.GetOrCreateAsync(key, async entry => await GetAsync());
#pragma warning restore CS4014
    }
}

public record UpdateField<TObject>(Expression<Func<TObject, object>> Field, object Value) where TObject : Entity;