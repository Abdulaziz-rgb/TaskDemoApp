using TaskDemoAPI.DTO;
using TaskDemoAPI.Entities;

namespace TaskDemoAPI;

public static class Extensions
{
    public static ItemDto AsDto(this Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            ItemPrice = new Price
            {
                Amount = item.ItemPrice.Amount,
                CurrencyType = item.ItemPrice.CurrencyType
            },
            ItemQuantity = new Quantity
            {
                Count = item.ItemQuantity.Count,
                QuantityType = item.ItemQuantity.QuantityType
            }
        };
    }

    public static Item CreateDto(this CreateItemDto item)
    {
        return new Item
        {
            Name = item.Name,
            ItemPrice = new Price
            {
                Amount = item.ItemPrice.Amount,
                CurrencyType = item.ItemPrice.CurrencyType
            },
            ItemQuantity = new Quantity
            {
                Count = item.ItemQuantity.Count,
                QuantityType = item.ItemQuantity.QuantityType
            }
        };
    }

     public static Item UpdateDto(this UpdateItemDto item)
     {
         return new Item
         {
             Name = item.Name,
             ItemPrice = new Price
             {
                 Amount = item.ItemPrice.Amount,
                 CurrencyType = item.ItemPrice.CurrencyType
             },
             ItemQuantity = new Quantity
             {
                 Count = item.ItemQuantity.Count,
                 QuantityType = item.ItemQuantity.QuantityType
             }
         };
     }
}