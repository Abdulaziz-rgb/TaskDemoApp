using System.ComponentModel.DataAnnotations;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class CreateItemDto
{
   
    [Required] 
    public string? Name { get; set; }
    
    public Price? ItemPrice { get; set; }
    
    public Quantity? ItemQuantity { get; set; }
}