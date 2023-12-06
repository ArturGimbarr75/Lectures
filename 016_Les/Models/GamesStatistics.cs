using Newtonsoft.Json;
using System.Linq;

internal class GamesStatistics : IGameStatistics
{
	public string GameName => "All games";

	public int GamesPlayed => Games.Sum(g => g.GamesPlayed);
	public int GamesWon => Games.Sum(g => g.GamesWon);
	public int GamesLost => Games.Sum(g => g.GamesLost);

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
