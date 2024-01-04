// 1
{
	string[] doubles =
	{
		"0.0",
		"0,1",
		"double",
		null,
		"1.0E1556",
		"5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555"
	};

	foreach (string value in doubles)
	{
		try
		{
			double.Parse(value);
			Console.WriteLine($"Converted '{value}' to double.");
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Unable to convert '{value}' to a double.");
			Console.WriteLine(ex.Message);
		}
		catch (OverflowException ex)
		{
			Console.WriteLine($"'{value}' is outside the range of a double.");
			Console.WriteLine(ex.Message);
		}
		catch (ArgumentNullException ex)
		{
			Console.WriteLine($"'{value}' is null.");
			Console.WriteLine(ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"'{value}' is not a double.");
			Console.WriteLine(ex.Message);
		}
	}
}

// 2
{
	var arr = new int[5] { 1, 2, 3, 4, 5 };
	for (int i = 0; i < arr.Length; i++)
	{
		Console.WriteLine(arr[i]);
	}

	try
	{
		Console.WriteLine(arr[5]);
	}
	catch (IndexOutOfRangeException ex)
	{
		Console.WriteLine(ex.Message);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}

// 3
{
	int[] arr = { 19, 0, 75, 52 };

	for (int i = 0; i < arr.Length; i++)
	{
		try
		{
			Console.WriteLine(arr[i] / arr[i + 1]);
		}
		catch (DivideByZeroException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (IndexOutOfRangeException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}

// 4
{
	try
	{
		string text = File.ReadAllText("test.txt");
		Console.WriteLine(text);
	}
	catch (FileNotFoundException ex)
	{
		Console.WriteLine(ex.Message);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}
