internal class StatisticsMenu : MenuWindowBase
{
	public StatisticsMenu(MenuWindowBase? parrent) : base(parrent)
	{

	}

	public override MenuWindowBase? Show()
	{
		base.Show();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Statistics");
		Console.ResetColor();

		int i = 1;
		var statistics = AuthorizedUser.Instance!.GamesStatistics;
		for (; i <= statistics.Games.Length; i++)
		{
			Console.WriteLine($"{i}. {statistics.Games[i - 1].GameName}");
		}

		Console.WriteLine($"{i++}. All games");
		Console.WriteLine($"{i}. Back");

		int choice = Choose(i);
		if (choice == i)
		{
			return _parrent;
		}
		else if (choice == i - 1)
		{
			Console.Clear();
			ShowAllStatistics();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			return this;
		}
		else if (choice > 0 && choice < i - 1)
		{
			Console.Clear();
			ShowStatistics(statistics.Games[choice - 1]);
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			return this;
		}
		else
		{
			Console.WriteLine("Invalid choice");
			return this;
		}
    }

	private void ShowStatistics(IGameStatistics statistics)
	{
		Console.WriteLine($"Games played: {statistics.GamesPlayed}");
		Console.WriteLine($"Games won: {statistics.GamesWon}");
		Console.WriteLine($"Games lost: {statistics.GamesLost}");
		Console.WriteLine($"Total score: {statistics.TotalScore}");
	}

	private void ShowAllStatistics()
	{
		var statistics = new List<IGameStatistics>(AuthorizedUser.Instance!.GamesStatistics.Games)
		{
			AuthorizedUser.Instance!.GamesStatistics
		};
		
		const int OFFSET = 2;
		int nameMaxLength = statistics.Max(gs => gs.GameName.Length);
		int playedMaxLength = statistics.Max(gs => gs.GamesPlayed.ToString().Length);
		int wonMaxLength = statistics.Max(gs => gs.GamesWon.ToString().Length);
		int lostMaxLength = statistics.Max(gs => gs.GamesLost.ToString().Length);
		int scoreMaxLength = statistics.Max(gs => gs.TotalScore.ToString().Length);

		nameMaxLength = Math.Max(nameMaxLength, "Game".Length);
		playedMaxLength = Math.Max(playedMaxLength, "Played".Length);
		wonMaxLength = Math.Max(wonMaxLength, "Won".Length);
		lostMaxLength = Math.Max(lostMaxLength, "Lost".Length);
		scoreMaxLength = Math.Max(scoreMaxLength, "Score".Length);

		string lineSepparator = $"+{new string('-', nameMaxLength + OFFSET)}" +
								$"+{new string('-', playedMaxLength + OFFSET)}" +
								$"+{new string('-', wonMaxLength + OFFSET)}" +
								$"+{new string('-', lostMaxLength + OFFSET)}" +
								$"+{new string('-', scoreMaxLength + OFFSET)}+";

		string format = $"|{{0,-{nameMaxLength + OFFSET}}}" +
						$"|{{1,-{playedMaxLength + OFFSET}}}" +
						$"|{{2,-{wonMaxLength + OFFSET}}}" +
						$"|{{3,-{lostMaxLength + OFFSET}}}" +
						$"|{{4,-{scoreMaxLength + OFFSET}}}|";

		Console.WriteLine(lineSepparator);
		Console.WriteLine(format, "Game", "Played", "Won", "Lost", "Score");
		Console.WriteLine(lineSepparator);
		foreach (var gameStatistics in statistics)
		{
			Console.WriteLine(format, gameStatistics.GameName, gameStatistics.GamesPlayed, gameStatistics.GamesWon,
								gameStatistics.GamesLost, gameStatistics.TotalScore);
			Console.WriteLine(lineSepparator);
		}

		var hangmanStatistics = AuthorizedUser.Instance!.GamesStatistics.Hangman;
		var tikTakToeStatistics = AuthorizedUser.Instance!.GamesStatistics.TikTakToe;
		var snakeStatistics = AuthorizedUser.Instance!.GamesStatistics.Snake;

		Console.WriteLine();
		Console.WriteLine("Scores");
		int hangmanMaxLength = Math.Max(hangmanStatistics.Scores.Max(s => s.ToString().Length), hangmanStatistics.GameName.Length);
		int tikTakToeMaxLength = Math.Max(tikTakToeStatistics.Scores.Max(s => s.ToString().Length), tikTakToeStatistics.GameName.Length);
		int snakeMaxLength = Math.Max(snakeStatistics.Scores.Max(s => s.ToString().Length), snakeStatistics.GameName.Length);

		lineSepparator = $"+{new string('-', hangmanMaxLength + OFFSET)}" +
						 $"+{new string('-', tikTakToeMaxLength + OFFSET)}" +
						 $"+{new string('-', snakeMaxLength + OFFSET)}+";

		format =	$"|{{0,-{hangmanMaxLength + OFFSET}}}" +
					$"|{{1,-{tikTakToeMaxLength + OFFSET}}}" +
					$"|{{2,-{snakeMaxLength + OFFSET}}}|";

		Console.WriteLine(lineSepparator);
		Console.WriteLine(format, hangmanStatistics.GameName, tikTakToeStatistics.GameName, snakeStatistics.GameName);
		Console.WriteLine(lineSepparator);

		int maxScores = Math.Max(hangmanStatistics.Scores.Count, Math.Max(tikTakToeStatistics.Scores.Count, snakeStatistics.Scores.Count));
		for (int i = 0; i < maxScores; i++)
		{
			string hangmanScore = i < hangmanStatistics.Scores.Count ? hangmanStatistics.Scores[i].ToString() : "";
			string tikTakToeScore = i < tikTakToeStatistics.Scores.Count ? tikTakToeStatistics.Scores[i].ToString() : "";
			string snakeScore = i < snakeStatistics.Scores.Count ? snakeStatistics.Scores[i].ToString() : "";
			Console.WriteLine(format, hangmanScore, tikTakToeScore, snakeScore);
			Console.WriteLine(lineSepparator);
		}
	}
}
