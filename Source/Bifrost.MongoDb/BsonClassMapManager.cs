using System;
using MongoDB.Bson.Serialization;

namespace Bifrost.MongoDb
{
    public class BsonClassMapManager : IBsonClassMapManager
    {
        public BsonClassMap<T> GetFor<T>()
        {
            if (BsonClassMap<T>.IsClassMapRegistered(typeof(T)))
                return BsonClassMap<T>.LookupClassMap(typeof(T)) as BsonClassMap<T>;

            throw new ArgumentException("Missing class map for type : '" + typeof(T).AssemblyQualifiedName + "'");
        }
    }
}
