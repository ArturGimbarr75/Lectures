// 1
{
	int number = 5;
	bool isPositive = number.IsPositive();
	Console.WriteLine($"Number {number} is {(isPositive? "positive" : "negative")}");
}

// 2
{
	int number = 5;
	bool isEven = number.IsEven();
	Console.WriteLine($"Number {number} is {(isEven? "even" : "odd")}");
}

// 3
{
	int number = 5;
	int valueToCompare = 3;
	bool isGreaterThan = number.IsGreaterThan(valueToCompare);
	Console.WriteLine($"Number {number} is {(isGreaterThan? "greater" : "less")} than {valueToCompare}");
}

// 4
{
	string text = "Hello World";
	bool containsSpaces = text.ContainsSpaces();
	Console.WriteLine($"Text '{text}' {(containsSpaces? "contains" : "does not contain")} spaces");
}

// 5
{
	string fullname = "John Doe";
	int yearOfBirth = 1990;
	string domain = "gmail.com";
	string email = fullname.ToEmailAddress(yearOfBirth, domain);
	Console.WriteLine($"Email address: {email}");
}

// 6
{
	var list = new List<int> { 1, 2, 3, 4, 5 };
	int? item = list.FindAndReturnIfEqual(3);
	Console.WriteLine($"Item: {item}");
}

// 7
{
	var list = new List<int> { 1, 2, 3, 4, 5 };
	var resultList = list.EveryOtherWord();
	Console.WriteLine($"Result list: {string.Join(", ", resultList)}");
}

// 8
{
	if (!File.Exists("file.txt"))
	{
		string defaultLines = "First line\nSecond line\nThird line\nFourth line\nFifth line";
		File.WriteAllText("file.txt", defaultLines);
	}
	var lines = Extensions.ReadEverySecondLine("file.txt");
	Console.WriteLine($"Lines: {string.Join(", ", lines)}");
}

static class Extensions
{
	// 1.
	public static bool IsPositive(this int number)
	{
		return number > 0;
	}

	// 2.
	public static bool IsEven(this int number)
	{
		return number % 2 == 0;
	}

	// 3.
	public static bool IsGreaterThan(this int number, int valueToCompare)
	{
		return number > valueToCompare;
	}

	// 4.
	public static bool ContainsSpaces(this string text)
	{
		return text.Contains(" ");
	}

	// 5.
	public static string ToEmailAddress(this string fullname, int yearOfBirth, string domain)
	{
		return $"{fullname.Replace(" ", "").ToLower()}{yearOfBirth}@{domain}";
	}

	// 6.
	public static T? FindAndReturnIfEqual<T>(this List<T> list, T item)
	{
		return list.FirstOrDefault(x => item?.Equals(x) ?? ReferenceEquals(item, x));
	}

	// 7.
	public static List<T> EveryOtherWord<T>(this List<T> list)
	{
		var resultList = new List<T>();
		for (int i = 0; i < list.Count; i += 2)
			resultList.Add(list[i]);

		return resultList;
	}

	// 8.
	public static IEnumerable<string> ReadEverySecondLine(string path)
	{
		var lines = File.ReadAllLines(path);
		for (int i = 0; i < lines.Length; i += 2)
		{
			yield return lines[i];
		}
	}
}