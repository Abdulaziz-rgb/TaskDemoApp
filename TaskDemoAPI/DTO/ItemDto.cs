using TaskDemoAPI.Entities;

namespace TaskDemoAPI.DTO;

    public class ItemDto
    {
        public string? Id { get; set; }
    
        public string? Name { get; set; }

        public Price ItemPrice { get; set; }

        public Quantity ItemQuantity { get; set; }
    }