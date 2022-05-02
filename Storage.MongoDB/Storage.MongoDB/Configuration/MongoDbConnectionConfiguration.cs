using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Configuration;

public sealed class MongoDbConnectionConfiguration
{
    public readonly string DbName;

    public readonly List<MongoServerAddress> ServerAddresses;

    public MongoDbConnectionConfiguration(
        MongoDbConnectionConfigurationReader configurationReader
    )
    {
        var (dbName, serverAddresses) = configurationReader;

        if (dbName != null && serverAddresses is { Count: > 0 })
        {
            DbName = dbName;
            ServerAddresses = serverAddresses.Select(m => new MongoServerAddress(m)).ToList();
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
    [property: ConfigurationKeyName("server_addresses")]
    List<string>? ServerAddresses)
{
    public MongoDbConnectionConfigurationReader() : this(default, default)
    {
    }
}