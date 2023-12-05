internal class User
{
	public string Username { get; set; } = default!;
	public string Password { get; set; } = default!;
	public string Salt { get; set; } = default!;

	public GamesStatistics GamesStatistics { get; set; } = new();
}
