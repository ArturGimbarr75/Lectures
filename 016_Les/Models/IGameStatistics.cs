internal interface IGameStatistics
{
	string GameName { get; }
	public int GamesPlayed { get; }
	public int GamesWon { get; }
	public int GamesLost { get; }

	public int TotalScore { get; }
}
