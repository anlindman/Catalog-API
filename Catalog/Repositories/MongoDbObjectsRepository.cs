using MongoDB.Bson;
using MongoDB.Driver;
using Object = Catalog.Entities.Object; 

namespace Catalog.Repositories
{
    public class MongoDbObjectsRepository : IObjectsRepository
    {
        private const string databaseName = "catalog";
        private const string objectsCollectionName = "objects";
        private readonly IMongoCollection<Object> objectsCollection;
        private readonly FilterDefinitionBuilder<Object> filterBuilder = Builders<Object>.Filter;
        public MongoDbObjectsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            objectsCollection = database.GetCollection<Object>(objectsCollectionName);
        }

        public async Task CreateObjectAsync(Object vobject)
        {
            await objectsCollection.InsertOneAsync(vobject);
        }

        public async Task DeleteObjectAsync(Guid id)
        {
            var filter = filterBuilder.Eq(vobject => vobject.Id, id);
            await objectsCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Object>> GetAllObjectsAsync()
        {
            return await objectsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Object> GetObjectAsync(Guid id)
        {
            var filter = filterBuilder.Eq(vobject => vobject.Id, id);
            return await objectsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateObjectAsync(Object vobject)
        {
            var filter = filterBuilder.Eq(existingObject => existingObject.Id, vobject.Id);
            await objectsCollection.ReplaceOneAsync(filter, vobject);
        }
    }
}
