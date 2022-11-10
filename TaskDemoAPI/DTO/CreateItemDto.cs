using System.ComponentModel.DataAnnotations;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class CreateItemDto
{
    [Required] 
    public string Name { get; set; }
    
    [Required]
    public Price Price { get; set; }
    
    [Required]
    public Quantity Quantity { get; set; }
}