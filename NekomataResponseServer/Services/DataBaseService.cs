using System;
using System.Collections.Generic;
using Log5RLibs.Services;
using MongoDB.Driver;
using NekomataResponseServer.Schemes;
using static NekomataResponseServer.Schemes.LoggerScheme;

namespace NekomataResponseServer.Services {
    public static class DataBaseService {
        public const int MaxIndex = -15;
        public static List<UpcomingScheme> GetDocuments(MongoClient client, string databaseName, string collectionName) {
            List<UpcomingScheme> schemes = new List<UpcomingScheme>();
            IMongoDatabase databaseHololive = client.GetDatabase(databaseName);
            IMongoCollection<UpcomingScheme> upcomingCollection = databaseHololive.GetCollection<UpcomingScheme>(collectionName);
            IAggregateFluent<UpcomingScheme> aggregateObject = upcomingCollection.Aggregate();
            schemes = aggregateObject.ToList();

            AlConsole.WriteLine(DB_INFO_C, $"Requested {databaseName, MaxIndex} | {collectionName, MaxIndex} |");
            
            return schemes;
        }
    }
}