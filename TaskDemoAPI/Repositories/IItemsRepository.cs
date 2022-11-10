using TaskDemoAPI.Entities;

namespace TaskDemoAPI.Services;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    
    Task<Item?> GetItemAsync(string id);
    
    Task<Item> CreateItemAsync(Item newItem);
    
    Task UpdateItemAsync(Item item);
    Task<Item> UpdateQuantityAsync(string id, Quantity quantity);
    
    Task DeleteItemAsync(string id);
}