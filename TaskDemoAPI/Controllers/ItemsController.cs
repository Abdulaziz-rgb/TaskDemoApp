using Microsoft.AspNetCore.Mvc;
using TaskDemoAPI.DTO;
using TaskDemoAPI.Entities;
using TaskDemoAPI.Services;

namespace TaskDemoAPI.Controllers;


[ApiController]
[Route("api/controller")]
public class ItemsController : ControllerBase
{

    private readonly IItemsRepository _itemsRepository;

    public ItemsController(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<ItemDto>> GetItems()
    {
        var items =  await _itemsRepository.GetItemsAsync();
        return items.Select(item => item.AsDto());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ItemDto>> GetItem(string id)
    {
        var item = await _itemsRepository.GetItemAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        return item.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem([FromBody] CreateItemDto newItem)
    {
        Item item = new()
        {
            Name = newItem.Name,
            ItemPrice = new Price()
            {
                Amount = newItem.ItemPrice.Amount,
                CurrencyType = newItem.ItemPrice.CurrencyType
            },
            ItemQuantity = new Quantity()
            {
                Count = newItem.ItemQuantity.Count,
                QuantityType = newItem.ItemQuantity.QuantityType
            }
        };

        await _itemsRepository.CreateItemAsync(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    [HttpPut("{id:length(24)}")]
    public async Task<ActionResult> UpdateItem(string id, UpdateItemDto itemDto)
    {
        var item = await _itemsRepository.GetItemAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        Item updatedItem = item with
        {
            Name = itemDto.Name,
            ItemPrice = new Price()
            {
                Amount = itemDto.ItemPrice.Amount,
                CurrencyType =  itemDto.ItemPrice.CurrencyType
            },
            ItemQuantity = new Quantity()
            {
                Count = itemDto.ItemQuantity.Count,
                QuantityType = itemDto.ItemQuantity.QuantityType
            }
        };
       
        await _itemsRepository.UpdateItemAsync(updatedItem);

        return NoContent();
    }
    
    
    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> DeleteItem(string id)
    {

        var item =  _itemsRepository.GetItemAsync(id);

        await _itemsRepository.DeleteItemAsync(id);

        return NoContent();

    }

}