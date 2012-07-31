using MongoDB.Bson.Serialization;

namespace Bifrost.MongoDb
{
    public interface IBsonClassMapManager
    {
        BsonClassMap<T> GetFor<T>();
    }
}
