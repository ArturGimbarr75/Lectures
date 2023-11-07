int GetNumber(Func<int, bool>? predicate = null, string inputMsg = "Enter a number: ", string invalidMsg = "Invalid input!")
{
	predicate ??= _ => true;
	int num;

	while (true)
	{
		Console.ResetColor();
		Console.Write(inputMsg);
		Console.ForegroundColor = ConsoleColor.Green;
		string? input = Console.ReadLine();

		if (int.TryParse(input, out num) && predicate(num))
		{
			Console.ResetColor();
			break;
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(invalidMsg);
			Console.ResetColor();
		}
	}

	return num;
}

// 1.1
{
	int dayOfWeek = GetNumber(x => x is >= 1 and <= 7, "Enter a day: ");

	string day = dayOfWeek switch
	{
		1 => "Monday",
		2 => "Tuesday",
		3 => "Wednesday",
		4 => "Thursday",
		5 => "Friday",
		6 => "Saturday",
		7 => "Sunday",
		_ => "Invalid day",
	};
	Console.WriteLine(day);
}

// 1.2
{
	int age = GetNumber(x => x > 0, "Enter your age: ");
	string ageDescription = age switch
	{
		<= 18 and >= 7 => "Student",
		> 18 and <= 25 => "Student",
		> 25 and <= 65 => "Employee",
		> 65 => "Pensioner",
		_ => "Other",
	};
	Console.WriteLine(ageDescription);
}

// 1.3
{
	int month = GetNumber(x => x is >= 1 and <= 12, "Enter a month: ");
	string monthName = month switch
	{
		1 => "January",
		2 => "February",
		3 => "March",
		4 => "April",
		5 => "May",
		6 => "June",
		7 => "July",
		8 => "August",
		9 => "September",
		10 => "October",
		11 => "November",
		12 => "December",
		_ => "Invalid month"
	};
	Console.WriteLine(monthName);
}

// 2.1
{
    Console.WriteLine(
	"""
	1. Square
	2. Triangle
	3. Rectangle
	4. Circle
	""");

	int shapeType = GetNumber(x => x is >= 1 and <= 4, "Enter a shape: ");

	Func<float> calcArea = shapeType switch
	{
		1 => () =>
		{
			float side = GetNumber(x => x > 0, "Enter a side of square: ");
			return side * side;
		},
		2 => () =>
		{
			float a = GetNumber(x => x > 0, "Enter a first side of triangle: ");
			float b = GetNumber(x => x > 0, "Enter a second side of triangle: ");
			float c = GetNumber(x => x > 0, "Enter a third side of triangle: ");
			float p = (a + b + c) / 2;
			return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		},
		3 => () =>
		{
			float a = GetNumber(x => x > 0, "Enter a first side of rectangle: ");
			float b = GetNumber(x => x > 0, "Enter a second side of rectangle: ");
			return a * b;
		},
		4 => () =>
		{
			float r = GetNumber(x => x > 0, "Enter a radius of circle: ");
			return (float)Math.PI * r * r;
		},
	};

	float area = calcArea();
	Console.WriteLine($"Area: {area}");
}

// 2.2
{
	Console.WriteLine(
	"""
	1. Fire
	2. Water
	3. Air
	4. Earth
	5. Ether
	""");

	int element = GetNumber(x => x is >= 1 and <= 5, "Enter an element: ");
	string elementDescription = element switch
	{
		1 => "Fire is hot and dry",
		2 => "Water is cold and wet",
		3 => "Air is hot and wet",
		4 => "Earth is cold and dry",
		5 => "Ether is hot and dry",
		_ => "Invalid element"
	};
    Console.WriteLine(elementDescription);
}

// 2.3
{
    Console.WriteLine(
	"""
	1. Maths
	2. Computer Science
	3. Biology
	4. Chemistry
	""");

	int subject = GetNumber(x => x is >= 1 and <= 4, "Enter a subject: ");
	int mark = GetNumber(x => x is >= 1 and <= 10, "Enter a mark (1 - 10): ");
	int exam = GetNumber(x => x is >= 1 and <= 100, "Enter an exam mark (1 - 100): ");

    Console.WriteLine($"Your probability to gain admission is {Random.Shared.Next(0, 101)}%");
}

// 3.1
{
	int month = GetNumber(x => x is >= 1 and <= 12, "Enter a month: ");
	string season = month switch
	{
		12 or 1 or 2 => "Winter",
		3 or 4 or 5 => "Spring",
		6 or 7 or 8 => "Summer",
		9 or 10 or 11 => "Autumn",
		_ => "Invalid month"
	};
	Console.WriteLine(season);
}

// 3.2
{
	// math operations
    Console.WriteLine(
	"""
	1. Addition
	2. Subtraction
	3. Multiplication
	4. Division
	5. Power
	6. Root
	""");

	int operation = GetNumber(x => x is >= 1 and <= 6, "Enter an operation: ");
	float a = GetNumber(inputMsg: "Enter a first number: ");
	float b = GetNumber(inputMsg: "Enter a second number: ");

	float result = operation switch
	{
		1 => a + b,
		2 => a - b,
		3 => a * b,
		4 => a / b,
		5 => MathF.Pow(a, b),
		6 => MathF.Pow(a, 1 / b),
		_ => 0
	};

	Console.WriteLine($"Result: {result}");
}

// 3.3
{
    Console.WriteLine(
	"""
	1. USD
	2. EUR
	3. GBP
	4. JPY
	""");
    int currency = GetNumber(x => x is >= 1 and <= 4, "Enter a currency: ");
	float amount = GetNumber(x => x > 0, "Enter an amount: ");

	string amountConverted = currency switch
	{
		1 => 
		$"""
		USD -> {amount}
		EUR -> {amount * 0.85}
		GBP -> {amount * 0.72}
		JPY -> {amount * 109.89}
		""",
		2 =>
		$"""
		USD -> {amount * 1.18}
		EUR -> {amount}
		GBP -> {amount * 0.85}
		JPY -> {amount * 130.21}
		""",
		3 =>
		$"""
		USD -> {amount * 1.38}
		EUR -> {amount * 1.17}
		GBP -> {amount}
		JPY -> {amount * 152.96}
		""",
		4 =>
		$"""
		USD -> {amount * 0.0091}
		EUR -> {amount * 0.0077}
		GBP -> {amount * 0.0065}
		JPY -> {amount}
		""",
		_ => "Invalid currency"
	};

	Console.WriteLine(amountConverted);
}