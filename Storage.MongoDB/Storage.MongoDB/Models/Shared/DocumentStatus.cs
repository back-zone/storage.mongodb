using System;

namespace Back.Zone.Storage.MongoDB.Models.Shared
{
    public sealed record DocumentStatus(
        bool IsActive,
        bool HasDeleted,
        DateTime? DeletedAt,
        DateTime CreatedAt
    )
    {
        public static DocumentStatus ForNew() => new(true, false, null, DateTime.Now);
        public static DocumentStatus ForNew(bool isActive) => new(isActive, false, null, DateTime.Now);
    }
}