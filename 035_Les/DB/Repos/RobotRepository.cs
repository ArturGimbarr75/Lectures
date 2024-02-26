using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DB.Repos;

internal class RobotRepository
{
    private readonly Database _db;

    public RobotRepository(Database db)
    {
        _db = db;
    }

	public async Task<IEnumerable<Guid>> GetAllIds()
	{
		var robots = await _db.RobotCollection.Find(new BsonDocument()).ToListAsync();
		return robots.Select(r => r["_id"].AsGuid);
	}

    public async Task<List<Robot>> GetAllRobots()
    {
		var robots = await _db.RobotCollection.Find(new BsonDocument()).ToListAsync();
		return robots.Select(r => BsonSerializer.Deserialize<Robot>(r)).ToList();
	}

    public async Task<Robot> GetRobotById(Guid id)
    {
		var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
		var robot = await _db.RobotCollection.Find(filter).FirstOrDefaultAsync();
		return BsonSerializer.Deserialize<Robot>(robot);
	}

	public async Task CreateRobot(Robot robot)
	{
		await _db.RobotCollection.InsertOneAsync(robot.ToBsonDocument());
	}

	public async Task UpdateRobot(Robot robot)
	{
		var filter = Builders<BsonDocument>.Filter.Eq("_id", robot.Id);
		await _db.RobotCollection.ReplaceOneAsync(filter, robot.ToBsonDocument());
	}

	public async Task DeleteRobot(Guid id)
	{
		var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
		await _db.RobotCollection.DeleteOneAsync(filter);
	}
}
