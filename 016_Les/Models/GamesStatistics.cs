using Newtonsoft.Json;

internal class GamesStatistics : IGameStatistics
{
	public string GameName => "All games";

	public int GamesPlayed => GamesLost + GamesWon;
	public int GamesWon => Hangman.GamesWon;
	public int GamesLost => Hangman.GamesLost;

	public int TotalScore => Games.Select(gs => gs.TotalScore).Sum();

	public HangmanStatistics Hangman { get; set; } = new();
	public TikTakToeStatistics TikTakToe { get; set; } = new();
	public SnakeStatistics Snake { get; set; } = new();

	[JsonIgnore]
	public IGameStatistics[] Games;

    public GamesStatistics()
	{
		Games =
		[
			Hangman,
			TikTakToe,
			Snake
		];
    }
}
