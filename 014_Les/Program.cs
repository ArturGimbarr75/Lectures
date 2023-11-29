Random r = Random.Shared;

// Task 1_1
{
	int GetRandomNumber() => Random.Shared.Next(1, 11);

    Console.WriteLine(GetRandomNumber());
}

// Task 1_2
{
	bool GetRandomBool() => r.Next() % 2 == 0;

	Console.WriteLine(GetRandomBool());
}

// Task 1_3
{
	int GetRandomNumber(int min, int max) => r.Next(min, max + 1);

	Console.WriteLine(GetRandomNumber(1, 10));
}

// Task 1_4
{
	Console.WriteLine(Enumerable.Range(0, 100).Select(x => r.Next(1, 7)).Sum());
}

// Task 1_5
{
	int num = r.Next(1, 101);
	int guess = 0;

	while (guess != num)
	{
		Console.Write("Guess: ");
		guess = int.Parse(Console.ReadLine());
		if (guess < num)
			Console.WriteLine("Too low");
		else if (guess > num)
			Console.WriteLine("Too high");
		else
			Console.WriteLine("Correct!");
	}
}

// Task 3
{
	int[,] CreateRandomMatrix()
	{
		int n = r.Next(1, 9), m = r.Next(1, 9);
		int[,] matrix;
		matrix = new int[n, m];
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
				matrix[i, j] = r.Next(1, 81);
		return matrix;
	}

	(float evenPercent, float oddPercent) CountEvenOdd(int[,] matrix)
	{
		int even = 0, odd = 0;
		foreach (int i in matrix)
			if (i % 2 == 0)
				even++;
			else
				odd++;
		return ((float)even / matrix.Length * 100, (float)odd / matrix.Length * 100);
	}

	void PrintMatrix(int[,] matrix)
	{
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
				Console.Write($"{matrix[i, j],3}");
			Console.WriteLine();
		}
	}

	int[,] matrix = CreateRandomMatrix();
	PrintMatrix(matrix);
	(float evenPercent, float oddPercent) = CountEvenOdd(matrix);
	Console.WriteLine($"Even: {evenPercent}%\nOdd: {oddPercent}%");

}