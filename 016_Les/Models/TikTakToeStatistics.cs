internal class TikTakToeStatistics : IGameStatistics
{
	public string GameName => "TikTakToe";

	public int GamesPlayed { get; set; }
	public int GamesWon { get; set; }
	public int GamesLost { get; set; }

	public int TotalScore => Scores.Sum();
	public List<int> Scores { get; set; } = new();
}
