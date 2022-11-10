using System.ComponentModel.DataAnnotations;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

public class UpdateItemDto
{
    public string? Name { get; set; }

    public Price? ItemPrice { get; set; }
}