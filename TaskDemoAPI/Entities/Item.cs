using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskDemoAPI.Entities;

public record Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    
    public string? Name { get; init; }

    public Price Price { get; init; }

    public Quantity Quantity { get; init; }

    public List<Quantity> QuantityHistories { get; set; } = new();
}
