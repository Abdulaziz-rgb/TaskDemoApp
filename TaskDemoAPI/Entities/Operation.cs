using TaskDemoAPI.Enum;

namespace TaskDemoAPI.Entities;

public class Operation
{
    public OperationTypeEnum OperationType { get; set; }

    public decimal Count { get; set; }

}