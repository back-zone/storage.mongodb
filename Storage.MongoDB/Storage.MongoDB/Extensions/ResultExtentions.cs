using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Extensions
{
    public static class ResultExtentions
    {
        public static bool Succeed(this UpdateResult updateResult) =>
            updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

        public static bool Succeed(this DeleteResult deleteResult) =>
            deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}