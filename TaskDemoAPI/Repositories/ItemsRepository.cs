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
    
    public async Task<Item?> GetItemAsync(string id)
    {
        return await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        await _itemsCollection.InsertOneAsync(item);
        return item;
    }

     public async Task<Item> UpdateItemAsync(string id, Item item)
     {
         var filter = _filterBuilder.Eq(existingItem => existingItem.Id, id);
         await _itemsCollection.ReplaceOneAsync(filter, item);
         
         return await GetItemAsync(id);
     }

     public async Task<Item> UpdateQuantityAsync(string id, Quantity quantity, List<Quantity> history)
     {
         var filter = _filterBuilder.Eq(item => item.Id, id);
         var set = Builders<Item>.Update
             .Set(x => x.Quantity, quantity)
             .Set(x => x.QuantityHistories, history);
         await _itemsCollection.UpdateOneAsync(filter, set);

         return await GetItemAsync(id);
     }

    public async Task DeleteItemAsync(string id)
    {
        await _itemsCollection.DeleteOneAsync(id);
    }
}