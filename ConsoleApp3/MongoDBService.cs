using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ConsoleApp3
{
    internal class MongoDBService
    {
        private IMongoDatabase _database;
        private const string connectionString = "mongodb://localhost:27017";
        private const string databaseName = "TaskManager";
        public MongoDBService()
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
