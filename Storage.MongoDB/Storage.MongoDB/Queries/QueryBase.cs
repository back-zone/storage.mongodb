using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Queries;

public static class QueryBase
{
    public static FilterDefinitionBuilder<TA> Filter<TA>() => Builders<TA>.Filter;

    public static UpdateDefinitionBuilder<TA> Updater<TA>() => Builders<TA>.Update;

    public static ProjectionDefinitionBuilder<TA> Projection<TA>() => Builders<TA>.Projection;

    public static SortDefinitionBuilder<TA> Sorter<TA>() => Builders<TA>.Sort;
}