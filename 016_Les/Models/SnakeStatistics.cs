internal class SnakeStatistics : IGameStatistics
{
	public string GameName => "Snake";

	public int GamesPlayed { get; set; }
	public int GamesWon => 0;
	public int GamesLost => 0;

	public int TotalScore => Scores.Sum();
	public List<int> Scores { get; set; } = new();
}
