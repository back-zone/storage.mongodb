using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Back.Zone.Storage.MongoDB.Models.MongoDb.BaseModels;

public sealed record DocumentStatus(
    [property: BsonElement("is_active")] bool IsActive,
    [property: BsonElement("has_deleted")] bool HasDeleted,
    [property: BsonElement("last_update_date")]
    DateTime LastUpdateDate,
    [property: BsonElement("creation_date")]
    DateTime CreationDate
)
{
    public static DocumentStatus CreateInActiveMode() => new(true, false, DateTime.Now, DateTime.Now);

    public static DocumentStatus CreateWithIsActive(bool isActive) => new(isActive, false, DateTime.Now, DateTime.Now);
}