// Task 1
{
    Console.WriteLine("Task 1");
    Dictionary<string, int> nameAge = new ()
	{
		{"John", 25},
		{"Mary", 27},
		{"Anne", 24}
	};

	foreach (KeyValuePair<string, int> kvp in nameAge)
		Console.WriteLine($"{kvp.Key} is {kvp.Value} years old");
}

// Task 2
{
	Console.WriteLine("Task 2");
	Dictionary<string, string> countryCapital = new()
	{
		{"Bulgaria", "Sofia"},
		{"Germany", "Berlin"},
		{"France", "Paris"}
	};

	foreach (KeyValuePair<string, string> kvp in countryCapital)
		Console.WriteLine($"The capital of {kvp.Key} is {kvp.Value}");
}

// Task 3
{
	Console.WriteLine("Task 3");
	Dictionary<string, int> fruitCount = new()
	{
		{"apple", 5},
		{"orange", 3},
		{"banana", 2 },
		{"kiwi", 1}
	};

	foreach (KeyValuePair<string, int> kvp in fruitCount)
		Console.WriteLine($"There are {kvp.Value} {kvp.Key}s");
}

// Task 4
{
	Console.WriteLine("Task 4");
	Dictionary<string, int> countryPopulation = new()
	{
		{"Bulgaria", 7_000_000},
		{"Germany", 83_000_000},
		{"France", 67_000_000},
		{"Spain", 47_000_000},
		{"Italy", 60_000_000},
		{"Greece", 10_000_000},
		{"Portugal", 10_000_000},
		{"Romania", 19_000_000},
		{"Hungary", 10_000_000},
		{"Austria", 9_000_000},
		{"Switzerland", 8_000_000},
		{"Belgium", 11_000_000},
		{"Netherlands", 17_000_000},
		{"Denmark", 6_000_000},
		{"Sweden", 10_000_000},
		{"Norway", 5_000_000},
		{"Finland", 5_000_000},
		{"Poland", 38_000_000},
		{"Czechia", 11_000_000},
		{"Slovakia", 5_000_000},
		{"Slovenia", 2_000_000},
		{"Croatia", 4_000_000},
		{"Bosnia and Herzegovina", 3_000_000},
		{"Serbia", 7_000_000},
		{"Albania", 3_000_000},
		{"North Macedonia", 2_000_000},
		{"Ukraine", 44_000_000},
		{"Belarus", 9_000_000},
		{"Moldova", 3_000_000},
		{"Russia", 144_000_000},
		{"Turkey", 83_000_000},
		{"Cyprus", 1_000_000},
		{"Ireland", 5_000_000},
		{"United Kingdom", 67_000_000},
	};

	for (int i = 0; i < countryPopulation.Count; i++)
	{
		Console.WriteLine($"{i + 1, 3}) {countryPopulation.ElementAt(i).Key}");
	}

	Console.WriteLine("Select country: ");
	int nr = int.Parse(Console.ReadLine());

	Console.WriteLine($"The population of {countryPopulation.ElementAt(nr - 1).Key} is {countryPopulation.ElementAt(nr - 1).Value}");
}

// Task 5
{
	Console.WriteLine("Task 5");
	Dictionary<string, string> wordTranslation = new()
	{
		{"apple", "ябълка"},
		{"orange", "портокал"},
		{"banana", "банан"},
		{"kiwi", "киви"}
	};

	foreach (KeyValuePair<string, string> kvp in wordTranslation)
		Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}

// Task 6
{
	Console.WriteLine("Task 6");
	Dictionary<string, int> nameGrade = new()
	{
		{"John", 5},
		{"Mary", 6},
		{"Anne", 4}
	};

	foreach (KeyValuePair<string, int> kvp in nameGrade)
		Console.WriteLine($"{kvp.Key} has grade {kvp.Value}");
}

// Task 7
{
	Console.WriteLine("Task 7");
	Dictionary<string, int> monthDays = new()
	{
		{"January", 31},
		{"February", 28},
		{"March", 31},
		{"April", 30},
		{"May", 31},
		{"June", 30},
		{"July", 31},
		{"August", 31},
		{"September", 30},
		{"October", 31},
		{"November", 30},
		{"December", 31}
	};

	foreach (KeyValuePair<string, int> kvp in monthDays)
		Console.WriteLine($"{kvp.Key} has {kvp.Value} days");
}

// Task 8
{
	Console.WriteLine("Task 8");
	Dictionary<string, int> nameSalary = new()
	{
		{"John", 1000},
		{"Mary", 2000},
		{"Anne", 1500}
	};

	foreach (KeyValuePair<string, int> kvp in nameSalary)
		Console.WriteLine($"{kvp.Key} has salary {kvp.Value}");
}