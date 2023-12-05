using Newtonsoft.Json;

internal class MockUserTable
{
	private readonly List<User> _users = new();

	private const string FILENAME = "users.json";

    public MockUserTable()
    {
		if (!File.Exists(FILENAME))
			File.Create(FILENAME).Close();
		string json = File.ReadAllText(FILENAME);
        _users = JsonConvert.DeserializeObject<List<User>>(json) ?? new();
    }

    public void AddUser(User user)
	{
		_users.Add(user);
		string json = JsonConvert.SerializeObject(_users, Formatting.Indented);
		File.WriteAllText(FILENAME, json);
	}

	public bool UserExists(string username)
	{
		return _users.Any(user => user.Username == username);
	}

	public bool UserExists(string username, string password)
	{
		return _users.Any(user => user.Username == username && user.Password == password);
	}

	public User? GetUser(string username)
	{
		return _users.FirstOrDefault(user => user.Username == username);
	}

	public bool ValidatePassword(string username, string hashedPassword)
	{
		User? user = GetUser(username);
		return user?.Password == hashedPassword;
	}

	public void UpdateUser(User user)
	{
		User? oldUser = GetUser(user.Username);

		_users.Remove(oldUser);
		_users.Add(user);
		string json = JsonConvert.SerializeObject(_users, Formatting.Indented);
		File.WriteAllText(FILENAME, json);
	}
}
