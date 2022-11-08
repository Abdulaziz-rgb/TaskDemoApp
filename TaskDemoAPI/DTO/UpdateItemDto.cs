using System.ComponentModel.DataAnnotations;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class UpdateItemDto
{
    [Required ] 
    public string? Name { get; set; }

    public Price ItemPrice { get; set; }
    
    public Quantity ItemQuantity { get; set; }
}