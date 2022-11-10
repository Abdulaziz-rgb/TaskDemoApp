using TaskDemoAPI.Enum;

namespace TaskDemoAPI.DTO;

public class OperationDto
{
    public OperationTypeEnum OperationType { get; set; }

    public decimal Count { get; set; }
}