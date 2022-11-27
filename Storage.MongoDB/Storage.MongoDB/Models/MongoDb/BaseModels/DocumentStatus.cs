using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Back.Zone.Storage.MongoDB.Models.MongoDb.BaseModels;

public static class DocumentStatusSchema
{
    public const string IsActive = "is_active";
    public const string HasDeleted = "has_deleted";
    public const string LastUpdatedAt = "last_updated_at";
    public const string CreatedAt = "created_at";
}

public sealed record DocumentStatus(
    [property: BsonElement(DocumentStatusSchema.IsActive), JsonPropertyName(DocumentStatusSchema.IsActive)]
    bool IsActive,
    [property: BsonElement(DocumentStatusSchema.HasDeleted), JsonPropertyName(DocumentStatusSchema.HasDeleted)]
    bool HasDeleted,
    [property: BsonElement(DocumentStatusSchema.LastUpdatedAt), JsonPropertyName(DocumentStatusSchema.LastUpdatedAt)]
    DateTime LastUpdatedAt,
    [property: BsonElement(DocumentStatusSchema.CreatedAt), JsonPropertyName(DocumentStatusSchema.CreatedAt)]
    DateTime CreatedAt
)
{
    public static DocumentStatus Apply() => new(true, false, DateTime.UtcNow, DateTime.UtcNow);

    public static DocumentStatus CreateWithIsActive(bool isActive) =>
        new(isActive, false, DateTime.UtcNow, DateTime.UtcNow);
}