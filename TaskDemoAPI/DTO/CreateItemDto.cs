using System.ComponentModel.DataAnnotations;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class CreateItemDto
{
   
    [Required] 
    public string Name { get; set; }
    
    [Required]
    public Price ItemPrice { get; set; }
    
    [Required]
    public Quantity ItemQuantity { get; set; }
}