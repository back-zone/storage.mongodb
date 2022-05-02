using System;
using Back.Zone.Monads.EitherMonad;
using Back.Zone.Net.Http.TransferObjects.HttpResponseObjects;
using MongoDB.Bson;

namespace Back.Zone.Storage.MongoDB.Services.MongoDb;

public static class BsonService
{
    public static Either<ApiResponse, ObjectId> ParseId(string id)
    {
        var parseSucceed = ObjectId.TryParse(id, out var parsedId);

        return parseSucceed
            ? parsedId
            : ApiResponse.FailedWithMessage("id failed to parse");
    }

    public static Either<ApiResponse<TA>, ObjectId> ParseId<TA>(string id) where TA : class
    {
        var parseSucceed = ObjectId.TryParse(id, out var parseId);

        return parseSucceed
            ? parseId
            : ApiResponse<TA>.FailedWithMessage("id failed to parse");
    }

    public static Either<ApiResponse, Tuple<ObjectId, ObjectId>> ParseIds(string firstId, string secondId)
    {
        var firstParseSucceed = ObjectId.TryParse(firstId, out var parsedFirstId);
        var secondParseSucceed = ObjectId.TryParse(secondId, out var parsedSecondId);

        return firstParseSucceed && secondParseSucceed
            ? Tuple.Create(parsedFirstId, parsedSecondId)
            : ApiResponse.FailedWithMessage("ids failed to parse");
    }

    public static Either<ApiResponse<TA>, Tuple<ObjectId, ObjectId>> ParseIds<TA>(string firstId, string secondId)
        where TA : class
    {
        var firstParseSucceed = ObjectId.TryParse(firstId, out var parsedFirstId);
        var secondParseSucceed = ObjectId.TryParse(secondId, out var parsedSecondId);

        return firstParseSucceed && secondParseSucceed
            ? Tuple.Create(parsedFirstId, parsedSecondId)
            : ApiResponse<TA>.FailedWithMessage("ids failed to parse");
    }
}