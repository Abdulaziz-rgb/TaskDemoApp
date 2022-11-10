using Microsoft.AspNetCore.Mvc;
using TaskDemoAPI.DTO;
using TaskDemoAPI.Entities;
using TaskDemoAPI.Enum;
using TaskDemoAPI.Services;

namespace TaskDemoAPI.Controllers;


[ApiController]
[Route("api/items")]
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
        var items = await _itemsRepository.GetItemsAsync();
        return items.Select(item => item.AsDto());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ItemDto>> GetItem(string id)
    {
        var item = await _itemsRepository.GetItemAsync(id);
        if (item is null) return NotFound();

        return item.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem([FromBody] CreateItemDto newItem)
    {
        var item = newItem.CreateDto();
        var addedItem = await _itemsRepository.CreateItemAsync(item);
        
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, addedItem.AsDto());
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateItem(string id, [FromBody] UpdateItemDto itemDto)
    {
        var item = await _itemsRepository.GetItemAsync(id);
        if (item is null) return NotFound();
        
        var updatedItem = itemDto.UpdateDto();
        await _itemsRepository.UpdateItemAsync(updatedItem);

        return NoContent();
    }
    
    [HttpPut("{id:length(24)}/quantity")]
    public async Task<ActionResult<ItemDto>> UpdateItem(string id, [FromBody] QuantityDto quantity)
    {
        var item = await _itemsRepository.GetItemAsync(id);
        if (item is null) return NotFound();
        
        var newQuantity = new Quantity();
        newQuantity.Count = quantity.OperationType switch
        {
            OperationTypeEnum.ADD => item.ItemQuantity.Count + quantity.Count,
            OperationTypeEnum.SUB => item.ItemQuantity.Count - quantity.Count,
            _ => newQuantity.Count
        };
        
        var updatedItem = await _itemsRepository.UpdateQuantityAsync(id, newQuantity);
        return updatedItem.AsDto();
    }

    [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteItem(string id)
        {

            var item = _itemsRepository.GetItemAsync(id);

            await _itemsRepository.DeleteItemAsync(id);

            return NoContent();

        }
    
}