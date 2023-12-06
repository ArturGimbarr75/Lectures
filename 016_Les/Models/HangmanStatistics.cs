internal class HangmanStatistics : IScorableGameStatistics
{
	public string GameName => "Hangman";

	public int GamesPlayed => GamesLost + GamesWon;
	public int GamesWon { get; set; }
	public int GamesLost { get; set; }

	public int TotalScore => Scores?.Sum() ?? 0;
	public List<int> Scores { get; set; } = new();
}
