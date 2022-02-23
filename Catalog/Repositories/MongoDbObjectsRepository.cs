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

        public Task CreateObjectAsync(Entities.Object vobject)
        {
            throw new NotImplementedException();
        }

        public Task DeleteObjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Object>> GetAllObjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Object> GetObjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateObjectAsync(Entities.Object vobject)
        {
            throw new NotImplementedException();
        }
    }
}
