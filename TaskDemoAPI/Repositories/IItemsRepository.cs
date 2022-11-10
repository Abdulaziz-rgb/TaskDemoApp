using TaskDemoAPI.Entities;

namespace TaskDemoAPI.Services;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    
    Task<Item?> GetItemAsync(string id);
    
    Task<Item> CreateItemAsync(Item newItem);
    
    Task<Item> UpdateItemAsync(string id, Item item);
    Task<Item> UpdateQuantityAsync(string id, Quantity quantity, List<Quantity> history);
    
    Task DeleteItemAsync(string id);
}