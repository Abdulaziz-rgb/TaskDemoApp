﻿using TaskDemoAPI.DTO;
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
            Price = new Price
            {
                Amount = item.Price.Amount,
                CurrencyType = item.Price.CurrencyType
            },
            Quantity = new Quantity
            {
                Count = item.Quantity.Count,
                QuantityType = item.Quantity.QuantityType
            }
        };
    }

    public static Item CreateDto(this CreateItemDto item)
    {
        return new Item
        {
            Name = item.Name,
            Price = new Price
            {
                Amount = item.ItemPrice.Amount,
                CurrencyType = item.ItemPrice.CurrencyType
            },
            Quantity = new Quantity
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
             Price = new Price
             {
                 Amount = item.ItemPrice.Amount,
                 CurrencyType = item.ItemPrice.CurrencyType
             }
         };
     }

     public static Quantity QuantityDto(this QuantityDto quantityDto)
     {
         return new Quantity
         {
             Count = quantityDto.Count,
             QuantityType = quantityDto.QuantityType,
             OperationType = quantityDto.OperationType
         };
     } 
     
     
     
     
}