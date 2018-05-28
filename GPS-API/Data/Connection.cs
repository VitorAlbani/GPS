using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using GPS_API.Models;
using System.Configuration;
using MongoDB.Bson;

namespace GPS_API.Data
{
    public class Connection
    {
        private static Connection connection;
        private static IMongoDatabase database;

        public static Connection GetConnection()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
            return connection;
        }

        private Connection()
        {
            Connect();
        }

        public static void Connect()
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["MongoDbConn"].ConnectionString;
            string dbName = ConfigurationManager.AppSettings["MongoDbName"];

            IMongoClient client = new MongoClient(cnnStr);
            database = client.GetDatabase(dbName);
        }

        public bool InsertFriend(Friend friend)
        {
            if (friend == null)
                return false;

            IMongoCollection<Friend> collection = database.GetCollection<Friend>("Friend");
            collection.InsertOne(friend);

            return true;
        }

        public List<Friend> GetFriends()
        {
            IMongoCollection<Friend> collection = database.GetCollection<Friend>("Friend");
            var filter = new BsonDocument();

            List<Friend> friends = collection.Find(filter).ToList();

            return friends;
        }
    }
}