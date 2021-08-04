using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Configuration
{
    public sealed class MongoDBConfiguration
    {
        public readonly string DbName;

        public readonly List<MongoServerAddress> ServerAddresses;

        public MongoDBConfiguration(MongoDBConfigurationReader mongoDbConfigurationReader)
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
                throw new ArgumentException("Check Mysql section on the config file!");
            }
        }
    }

    public sealed record MongoDBConfigurationReader(
        string? DbName,
        List<string>? ServerAddresses)
    {
        public const string SectionIndicator = "MongoDB";

        public MongoDBConfigurationReader() : this(default, default)
        {
        }
    }
}