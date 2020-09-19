using System.Collections.Generic;
using Log5RLibs.Services;
using MongoDB.Driver;
using NekomataResponseServer.Schemes;
using static NekomataResponseServer.Schemes.LoggerScheme;

namespace NekomataResponseServer.Services {
    public static class DataBaseService {
        private const int MaxIndex = -15;
        public static List<UpcomingScheme> GetDocuments(MongoClient client, string databaseName, string collectionName) {
            List<UpcomingScheme> schemes = new List<UpcomingScheme>();
            IMongoCollection<UpcomingScheme> upcomingCollection = ConnectDataBase(client, databaseName, collectionName);
            IAggregateFluent<UpcomingScheme> aggregateObject = upcomingCollection.Aggregate();
            schemes = aggregateObject.ToList();

            AlConsole.WriteLine(DB_INFO_C, $"Requested {databaseName, MaxIndex} | {collectionName, MaxIndex} |");
            
            return schemes;
        }

        public static List<string> GetCollectionNames(MongoClient client, string databaseName) {
            IMongoDatabase database = client.GetDatabase(databaseName);
            List<string> collectionNames = database.ListCollectionNames().ToList();
            AlConsole.WriteLine(DB_INFO_C, $"Requested {databaseName, MaxIndex} | {"CountCollection(s) [" + collectionNames.Count + "]", MaxIndex} |");
            return collectionNames;
        }

        private static IMongoCollection<UpcomingScheme> ConnectDataBase(MongoClient client, string databaseName, string collectionName) {
            IMongoDatabase database = client.GetDatabase(databaseName);
            return database.GetCollection<UpcomingScheme>(collectionName);
        }
    }
}