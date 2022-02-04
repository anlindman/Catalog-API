using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbCompanyRepository : ICompanyRepository
    {
        private const string databaseName = "catalog";
        private const string companyCollectionName = "companies";
        private readonly IMongoCollection<Company> companyCollection;
        private readonly FilterDefinitionBuilder<Company> filterBuilder = Builders<Company>.Filter;
        public MongoDbCompanyRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            companyCollection = database.GetCollection<Company>(companyCollectionName);
        }
        public async Task CreateCompanyAsync(Company company)
        {
            await companyCollection.InsertOneAsync(company);
        }

        public async Task DeleteCompanyAsync(Guid id)
        {
            var filter = filterBuilder.Eq(company => company.Id, id);
            await companyCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await companyCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            var filter = filterBuilder.Eq(company => company.Id, id);
            return await companyCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            var filter = filterBuilder.Eq(existingCompany => existingCompany.Id, company.Id);
            await companyCollection.ReplaceOneAsync(filter, company);
        }
    }
}
