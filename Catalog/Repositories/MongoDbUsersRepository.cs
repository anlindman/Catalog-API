﻿using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbUsersRepository : IUsersRepository
    {
        private const string databaseName = "catalog";
        private const string usersCollectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        public MongoDbUsersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(usersCollectionName);
        }
        public async Task CreateUserAsync(User user)
        {
            await usersCollection.InsertOneAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            await usersCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            await usersCollection.ReplaceOneAsync(filter, user);
        }
    }
}
