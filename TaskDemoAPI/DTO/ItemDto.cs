using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class ItemDto
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public Price Price { get; set; }

    public Quantity Quantity { get; set; }
}