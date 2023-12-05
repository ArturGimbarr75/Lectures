internal class GamesStatistics
{
	public int GamesPlayed => GamesLost + GamesWon;
	public int GamesWon => Hangman.GamesWon;
	public int GamesLost => Hangman.GamesLost;

	public HangmanStatistics Hangman { get; set; } = new();
}
