List<T> Filter<T>(List<T> ints, Func<T, bool> func)
{
	List<T> result = new List<T>();
	foreach (T i in ints)
		if (func(i))
			result.Add(i);
	return result;
}

// 1_1
{
	void PrintLengths(List<string> strings)
	{
		foreach (string s in strings)
		{
			Console.WriteLine($"{s, 9} has {s.Length} characters.");
		}
	}

	var strings = new List<string>
	{
		"Monday",
		"Tuesday",
		"Wednesday",
		"Thursday",
		"Friday",
		"Saturday",
		"Sunday"
	};

	PrintLengths(strings);
    Console.WriteLine();
}

// 1_2
{
	void Fill(int count, out List<int> ints)
	{
		ints = new List<int>(count);
		for (int i = 0; i < ints.Capacity; i++)
			ints.Add(Random.Shared.Next(0, 1000));
	}

	float Average(List<int> ints)
	{
		int sum = 0;
		foreach (int i in ints)
			sum += i;
		return (float)sum / ints.Count;
	}

	Fill(50, out List<int> ints);
    Console.WriteLine($"Average is {Average(ints)}");
}

// 1_3
{
	List<int> ints = Enumerable.Range(0, 20).Select(x => Random.Shared.Next(0, 100)).ToList();
	Console.WriteLine($"Original: {string.Join(", ", ints)}");
	Console.WriteLine($"Odd: {string.Join(", ", Filter(ints, x => x % 2 == 1))}");
	Console.WriteLine($"More than 10: {string.Join(", ", Filter(ints, x => x > 10))}");
}

// 1_4
{
	List<string> strings = new List<string>
	{
		"Monday",
		"Tuesday",
		"Wednesday",
		"Thursday",
		"Friday",
		"Saturday",
		"Sunday"
	};

	Console.WriteLine($"Original: {string.Join(", ", strings)}");
	Console.WriteLine($"Even: {string.Join(", ", Filter(strings, x => x.Select(x => (int)x).Sum() % 2 == 0))}");
}

// 1_5
{
	List<int> ints = Enumerable.Range(0, 10).ToList();
	
	List<int> Factorials(List<int> ints)
	{
		List<int> result = new List<int>();
		foreach (int i in ints)
		{
			int factorial = 1;
			for (int j = 1; j <= i; j++)
				factorial *= j;
			result.Add(factorial);
		}
		return result;
	}

	Console.WriteLine($"Original: {string.Join(", ", ints)}");
	Console.WriteLine($"Factorials: {string.Join(", ", Factorials(ints))}");
}

// 1_6
{
	List<string> strings = new List<string>
	{
		"Monday",
		"Tuesday",
		"Wednesday",
		"Thursday",
		"Friday",
		"Saturday",
		"Sunday"
	};

	bool IsPrime(int s)
	{
		if (s < 2)
			return false;
		for (int i = 2; i < s; i++)
			if (s % i == 0)
				return false;
		return true;
	}

	Console.WriteLine($"Original: {string.Join(", ", strings)}");
	Console.WriteLine($"Prime sum: {string.Join(", ", Filter(strings, x => IsPrime(x.Select(x => (int)x).Sum())))}");
}