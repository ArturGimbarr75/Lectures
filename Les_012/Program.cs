// Task 1_1
using System.Data.SqlTypes;

{
	float Average(params float[] numbers)
	{
		float sum = 0;
		foreach (float number in numbers)
			sum += number;
		return sum / numbers.Length;
	}

	float average = Average(1, 2, 3, 4, 5);
	Console.WriteLine(average);
}

// Task 1_2
{
	float[] GetPositiveNumbers(params float[] numbers)
	{
		List<float> positiveNumbers = new();
		foreach (float number in numbers)
			if (number > 0)
				positiveNumbers.Add(number);
		return positiveNumbers.ToArray();
	}

	Console.WriteLine(string.Join(", ", GetPositiveNumbers(1, -4, 5, 1, -520, -45, 4)));
}

// Task 1_3
{
	float CalculateVat(float vat = 0.15f, params float[] prices)
	{
		float sum = 0;
		foreach (float price in prices)
			sum += price;
		return sum * vat;
	}

	Console.WriteLine(CalculateVat(prices: [1, 2, 3, 4, 5]));
}

// Task 1_4
{
	string[] GetWordsLongerThan4Chars(string sentence)
	{
		return sentence.Split(" .,!?;:\n\t".ToCharArray()).Where(word => word.Length > 4).ToArray();
	}
	string longText =
		@"Hello, my name is John.
		I am 20 years old.
		I am a student at the University of Economics in Prague.";
	
	string[] words = GetWordsLongerThan4Chars(longText);
	Console.WriteLine(string.Join(", ", words));
}

// Task 1_5
{
	void ConstructDeck(string[] types, string[] cards)
	{
		string[][] deck = types.Select(type => cards.Select(card => $"{card} of {type}").ToArray()).ToArray();

        Console.WriteLine(new string('_', 91));
        foreach (string[] type in deck)
				Console.WriteLine($"|{type[0], 20} | {type[1], 20} | {type[2], 20} | {type[3], 20}|");
		Console.WriteLine($"|{new string('_', 21)}|{new string('_', 22)}|{new string('_', 22)}|{new string('_', 21)}|");
	}

	string[] types = {"Hearts", "Diamonds", "Clubs", "Spades"};
	string[] cards = {"Ace", "King", "Queen", "Jack"};
	ConstructDeck(types, cards);
}

// Task 2_1
{
	void PrintMatrix<T>(T?[,] matrix)
	{
		int maxLength = matrix.Cast<T?>().Select(x => x?.ToString()?.Length ?? 0).Max() + 1;
        Console.WriteLine(new string('=', matrix.GetLength(1) * (maxLength + 1) + 1));
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			Console.Write("|");
			for (int j = 0; j < matrix.GetLength(1); j++)
				Console.Write($"{(matrix[i, j]?.ToString() ?? "").PadLeft(maxLength)}|");
			Console.WriteLine();
            Console.WriteLine(new string('=', matrix.GetLength(1) * (maxLength + 1) + 1));
        }
	}

	int?[,] RemoveDublicates(int[,] matrix)
	{
		int?[,] newMatrix = new int?[matrix.GetLength(0), matrix.GetLength(1)];
		for (int i = 0; i < matrix.GetLength(0); i++)
			for (int j = 0; j < matrix.GetLength(1); j++)
				newMatrix[i, j] = matrix[i, j];

		for (int i = 0; i < matrix.GetLength(0); i++)
			for (int j = 0; j < matrix.GetLength(1); j++)
				for (int k = 0; k < matrix.GetLength(0); k++)
					for (int l = 0; l < matrix.GetLength(1); l++)
						if (matrix[i, j].Equals(matrix[k, l]) && !(i == k && j == l))
							newMatrix[k, l] = null;

		return newMatrix;
	}

	int rows, columns;
	Console.Write("Enter number of rows: ");
	rows = int.Parse(Console.ReadLine()!);
	Console.Write("Enter number of columns: ");
	columns = int.Parse(Console.ReadLine()!);

	int[,] matrix = new int[rows, columns];
    Console.WriteLine("Fill Matrix manualy? (y / n)");
	if (Console.ReadLine()!.ToLower() == "y")
	{
		for (int i = 0; i < rows; i++)
			for (int j = 0; j < columns; j++)
			{
				Console.Write($"Enter number for row {i + 1} and column {j + 1}: ");
				matrix[i, j] = int.Parse(Console.ReadLine()!);
			}
	}
	else
	{
		Random random = new();
		for (int i = 0; i < rows; i++)
			for (int j = 0; j < columns; j++)
				matrix[i, j] = random.Next(0, 100);
	}

	PrintMatrix(matrix);

	int?[,] newMatrix = RemoveDublicates(matrix);
    Console.WriteLine("Matrix without dublicates:");
    PrintMatrix(newMatrix);
}