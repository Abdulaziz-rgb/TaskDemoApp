using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.Services;

public class ItemsRepository : IItemsRepository
{
    private readonly IMongoCollection<Item> _itemsCollection;
    
    private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;

    public ItemsRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
     
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _itemsCollection = mongoDatabase.GetCollection<Item>(databaseSettings.Value.CollectionName);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
       return await _itemsCollection.Find(_ => true).ToListAsync();
    }
    
    public async Task<Item> GetItemAsync(string id)
    {
        return await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateItemAsync(Item newItem)
    {
        await _itemsCollection.InsertOneAsync(newItem);
    }

     public async Task UpdateItemAsync(Item item)
     {
         var filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
         await _itemsCollection.ReplaceOneAsync(filter, item);
     }
    

    public async Task DeleteItemAsync(string id)
    {
        await _itemsCollection.DeleteOneAsync(id);
    }
}