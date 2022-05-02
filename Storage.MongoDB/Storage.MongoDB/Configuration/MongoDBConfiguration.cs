using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Back.Zone.Storage.MongoDB.Configuration;

public sealed class MongoDbConfiguration
{
    public readonly List<MongoDbConnectionConfiguration> ConnectionConfigurations;

    public MongoDbConfiguration(MongoDbConfigurationReader configurationReader)
    {
        ConnectionConfigurations = new List<MongoDbConnectionConfiguration>();

        if (configurationReader.ConnectionConfigurationReaders == null)
            throw new ArgumentException("Failed to access MongoDb configurations!");

        foreach (var connectionConfigurationReader in configurationReader.ConnectionConfigurationReaders)
        {
            ConnectionConfigurations.Add(new MongoDbConnectionConfiguration(connectionConfigurationReader));
        }
    }
}

public sealed class MongoDbConfigurationReader
{
    [property: ConfigurationKeyName("connections")]
    public List<MongoDbConnectionConfigurationReader>? ConnectionConfigurationReaders { get; set; }

    public const string ConfigurationSectionName = "mongodb";
}