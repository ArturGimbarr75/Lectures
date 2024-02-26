using MongoDB.Bson;
using MongoDB.Driver;

namespace DB;

internal class Database
{
	public IMongoClient MongoClient { get; private set; }
	public IMongoDatabase MongoDatabase { get; private set; }
	public IMongoCollection<BsonDocument> RobotCollection { get; private set; }

	public Database()
    {
		MongoClient = new MongoClient("mongodb://localhost:27017");
		MongoDatabase = MongoClient.GetDatabase("robotsDb");
		RobotCollection = MongoDatabase.GetCollection<BsonDocument>("robots");
	}
}
