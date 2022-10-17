using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Configuration;

public sealed class MongoDbConnectionConfiguration
{
    public readonly string DbName;

    public readonly MongoUrl MongoUrl;

    public MongoDbConnectionConfiguration(
        MongoDbConnectionConfigurationReader configurationReader
    )
    {
        var (dbName, connectionString) = configurationReader;

        if (!string.IsNullOrWhiteSpace(dbName) && !string.IsNullOrWhiteSpace(connectionString))
        {
            DbName = dbName;
            MongoUrl = new MongoUrl(connectionString);
        }
        else
        {
            throw new ArgumentException("MongoDb configuration is invalid.");
        }
    }
}

public sealed record MongoDbConnectionConfigurationReader(
    [property: ConfigurationKeyName("db_name")]
    string? DbName,
    [property: ConfigurationKeyName("connection_string")]
    string? ConnectionString)
{
    public MongoDbConnectionConfigurationReader() : this(default, default)
    {
    }
}