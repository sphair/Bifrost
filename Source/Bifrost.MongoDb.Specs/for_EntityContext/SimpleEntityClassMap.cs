using MongoDB.Bson.Serialization;

namespace Bifrost.MongoDB.Specs.for_EntityContext
{
    public class SimpleEntityClassMap : BsonClassMap<SimpleEntity>
    {
        public SimpleEntityClassMap()
        {
            AutoMap();
            SetIdMember(GetMemberMap(s => s.TheId));
        }
    }
}
