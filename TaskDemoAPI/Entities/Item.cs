using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskDemoAPI.Entities;

public record Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    
    public string? Name { get; init; }

    public Price ItemPrice { get; init; }

    public Quantity ItemQuantity { get; init; }
}
