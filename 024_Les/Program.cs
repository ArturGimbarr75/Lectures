// 1
{
	GerericTest<int, string> test = new(1, "test");
	test.PrintProperty1();
	test.PrintProperty2();
	test.SetProperty1(2);
	test.SetProperty2("test2");
	test.PrintProperty1();
	test.PrintProperty2();
}

// 2
{
	FourSideGeometricFigure figure = new("test", 2, 3);
	Generator<FourSideGeometricFigure> generator = new();
	generator.Show(figure);
}

// 3
{
	TypeClass<int> typeClass = new(1, 2);
	typeClass.PrintType(1);
}

// 4
{
	var soccerLeague = new League<Team>("Soccer");
	var soccerTeam = new Team("Lions", "Soccer");
	var basketballTeam = new Team("Eagles", "Basketball");

	soccerLeague.AddTeam(soccerTeam);
	try
	{
		soccerLeague.AddTeam(basketballTeam);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	soccerLeague.PrintTeams();
}

public class Team
{
	public string Name { get; set; }
	public string Sport { get; set; }

	public Team(string name, string sport)
	{
		Name = name;
		Sport = sport;
	}
}

public class League<T> where T : Team
{
	private List<T> _teams = new List<T>();
	private string _leagueSport;

	public League(string sport)
	{
		_leagueSport = sport;
	}

	public void AddTeam(T team)
	{
		if (team.Sport != _leagueSport)
		{
			throw new ArgumentException("Can't add a team from a different sport.");
		}

		_teams.Add(team);
	}

	public void PrintTeams()
	{
		foreach (var team in _teams)
		{
			Console.WriteLine(team.Name);
		}
	}
}