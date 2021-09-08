using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Configuration
{
    public sealed class MongoDbConfiguration
    {
        public readonly string DbName;

        public readonly List<MongoServerAddress> ServerAddresses;

        public MongoDbConfiguration(MongoDbConfigurationReader mongoDbConfigurationReader)
        {
            var (dbName, serverAddresses) = mongoDbConfigurationReader;

            if (dbName != null && serverAddresses is { Count: > 0 })
            {
                DbName = dbName;
                ServerAddresses = serverAddresses
                    .Select(m => new MongoServerAddress(m))
                    .ToList();
            }
            else
            {
                throw new ArgumentException("Check MongoDB section on the config file!");
            }
        }
    }

    public sealed record MongoDbConfigurationReader(
        string? DbName,
        List<string>? ServerAddresses)
    {
        public const string SectionIndicator = "MongoDB";

        public MongoDbConfigurationReader() : this(default, default)
        {
        }
    }
}