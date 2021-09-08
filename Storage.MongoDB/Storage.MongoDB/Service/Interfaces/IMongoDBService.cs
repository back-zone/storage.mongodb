using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Service.Interfaces
{
    public interface IMongoDbService
    {
        public IMongoCollection<TA> GetCollection<TA>(string collectionName);
    }
}