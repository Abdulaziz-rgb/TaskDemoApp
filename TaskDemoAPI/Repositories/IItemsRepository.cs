using TaskDemoAPI.Entities;

namespace TaskDemoAPI.Services;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    
    Task<Item> GetItemAsync(string id);
    
    Task CreateItemAsync(Item newItem);
    
    Task UpdateItemAsync(Item item);
    Task UpdateQuantityAsync(string id, Quantity quantity);
    
    Task DeleteItemAsync(string id);
}