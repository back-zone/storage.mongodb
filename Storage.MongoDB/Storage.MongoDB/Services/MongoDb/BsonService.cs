using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Back.Zone.Monads.IOMonad;
using MongoDB.Bson;

namespace Back.Zone.Storage.MongoDB.Services.MongoDb;

public static class BsonService
{
    public static IO<ObjectId> ParseObjectId(string id) =>
        ObjectId.TryParse(id, out var objectId)
            ? IO.Pure(objectId)
            : Failure.From<ObjectId>(new Exception("id failed to parse"));

    public static IO<ImmutableList<ObjectId>> ParseObjectIds(IEnumerable<string> ids)
    {
        ImmutableList<ObjectId> ParseList()
        {
            var parsedList = ids.Select(ParseObjectId).ToImmutableList();

            var failures = parsedList.Where(m => m.IsSuccess() == false).Select(m => m.Error()).ToImmutableList();

            return failures switch
            {
                { Count: > 0 } => throw failures.First(),
                _ => parsedList.Select(m => m.Get()).ToImmutableList()
            };
        }

        return IO.From(ParseList);
    }
}