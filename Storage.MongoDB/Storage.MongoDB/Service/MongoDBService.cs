using Back.Zone.Storage.MongoDB.Configuration;
using Back.Zone.Storage.MongoDB.Service.Interfaces;
using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Service
{
    public sealed class MongoDbService : IMongoDbService
    {
        private readonly string _dbName;
        private readonly MongoClient _mongoClient;

        public MongoDbService(MongoDbConfiguration mongoDbConfiguration)
        {
            _dbName = mongoDbConfiguration.DbName;
            _mongoClient = new MongoClient(new MongoClientSettings
            {
                Servers = mongoDbConfiguration.ServerAddresses
            });
        }

        public IMongoCollection<TA> GetCollection<TA>(string collectionName) =>
            _mongoClient
                .GetDatabase(_dbName)
                .GetCollection<TA>(collectionName);
    }
}