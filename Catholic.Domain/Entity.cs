using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catholic.Domain;

public class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public DateTime Date { get; set; } = DateTime.UtcNow;
}