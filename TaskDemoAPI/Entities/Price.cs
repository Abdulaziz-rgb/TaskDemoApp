using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TaskDemoAPI.Enum;

namespace TaskDemoAPI.Entities;

public class Price
{
    public decimal Amount { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)] 
    public CurrencyTypeEnum CurrencyType { get; set; }
}