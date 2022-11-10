using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TaskDemoAPI.Enum;

namespace TaskDemoAPI.Entities;

public class Quantity
{
    public decimal Count { get; set;}
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public QuantityTypeEnum QuantityType { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public OperationTypeEnum OperationType { get; set; }
}