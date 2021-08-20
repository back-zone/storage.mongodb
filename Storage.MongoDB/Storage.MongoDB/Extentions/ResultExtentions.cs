using MongoDB.Driver;

namespace Back.Zone.Storage.MongoDB.Extentions
{
    public static class ResultExtentions
    {
        public static bool HasSucceed(this UpdateResult updateResult) =>
            updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}