using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class ItemDto
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public PriceDto Price { get; set; }

    public QuantityDto Quantity { get; set; }
    
    public List<QuantityDto> QuantityHistories { get; set; }
}