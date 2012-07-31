using Bifrost.MongoDb;
using Machine.Specifications;
using MongoDB.Driver;
using Moq;

namespace Bifrost.MongoDB.Specs.for_EntityContext.given
{
    public class an_entity_context 
    {
        protected static EntityContextConnection  connection;
        protected static MongoServer mongo_server;
        protected static MongoDatabase mongo_database;
        protected static Mock<IMongoDbContext> mongo_db_context_mock;
        protected static Mock<IBsonClassMapManager> bson_class_map_manager_mock;
        protected static EntityContext<SimpleEntity> entity_context;

        Establish context = () =>
        {
            connection = new EntityContextConnection(string.Empty, string.Empty);

            mongo_db_context_mock = new Mock<IMongoDbContext>();

            bson_class_map_manager_mock = new Mock<IBsonClassMapManager>();
            bson_class_map_manager_mock.Setup(c => c.GetFor<SimpleEntity>()).Returns(new SimpleEntityClassMap());

            entity_context = new EntityContext<SimpleEntity>(connection, mongo_db_context_mock.Object, bson_class_map_manager_mock.Object);
        };
    }
}
