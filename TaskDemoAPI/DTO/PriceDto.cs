using TaskDemoAPI.Enum;

namespace TaskDemoAPI.DTO;

public class PriceDto
{
    public decimal Amount { get; set; }

    public CurrencyTypeEnum CurrencyType { get; set; }
}