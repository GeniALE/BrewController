using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrewController.Models;

public abstract class MongoCollectionItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = null!;
}
