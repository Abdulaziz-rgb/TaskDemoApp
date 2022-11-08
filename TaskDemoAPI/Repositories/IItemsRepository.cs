using TaskDemoAPI.Entities;

namespace TaskDemoAPI.Services;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    
    Task<Item> GetItemAsync(string id);
    
    Task CreateItemAsync(Item newItem);
    
    Task UpdateItemAsync(Item item);
    
    Task DeleteItemAsync(string id);
}