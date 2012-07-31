using MongoDB.Driver;

namespace Bifrost.MongoDB.Specs.for_EntityContext
{
    public class FakeMongoCollection<T> : MongoCollection<T>
    {
        public FakeMongoCollection(MongoDatabase database)
            : base(database,new MongoCollectionSettings<T>(database, typeof(T).Name))
        {
        }
    }
}
