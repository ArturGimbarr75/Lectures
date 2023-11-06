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
int number = GetNumber();

string message = number switch
{
	100 => "The number is equal to 100",
	> 100 => "The number is greater than 100",
	< 100 => "The number is less than 100",
};
Console.WriteLine(message);

if (number == 100)
	Console.WriteLine("The number is equal to 100");
else if (number > 100)
	Console.WriteLine("The number is greater than 100");
else if (number < 100)
	Console.WriteLine("The number is less than 100");

// 1.2

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

if (dayOfWeek == 1)
	Console.WriteLine("Monday");
else if (dayOfWeek == 2)
	Console.WriteLine("Tuesday");
else if (dayOfWeek == 3)
	Console.WriteLine("Wednesday");
else if (dayOfWeek == 4)
	Console.WriteLine("Thursday");
else if (dayOfWeek == 5)
	Console.WriteLine("Friday");
else if (dayOfWeek == 6)
	Console.WriteLine("Saturday");
else if (dayOfWeek == 7)
	Console.WriteLine("Sunday");
else
	Console.WriteLine("Invalid day");

// 2.1

number = GetNumber();

if (number % 2 == 0)
	Console.WriteLine("The number is even");
else if (number % 5 == 0)
	Console.WriteLine("The number is divisible by 5");
else
	Console.WriteLine("The number doesn't match any conditions");

// 2.2

int temperature = GetNumber(inputMsg: "Enter temperature: ");
string temperatureDescription = temperature switch
{
	< 0 => "Freezing",
	>= 0 and < 10 => "Cold",
	>= 10 and < 20 => "Cool",
	>= 20 and < 30 => "Warm",
	>= 30 => "Hot",
};
Console.WriteLine(temperatureDescription);

if (temperature < 0)
	Console.WriteLine("Freezing");
else if (temperature >= 0 && temperature < 10)
	Console.WriteLine("Cold");
else if (temperature >= 10 && temperature < 20)
	Console.WriteLine("Cool");
else if (temperature >= 20 && temperature < 30)
	Console.WriteLine("Warm");
else if (temperature >= 30)
	Console.WriteLine("Hot");

// 3.1

int hour = GetNumber(x => x is >= 0 and <= 24, "Enter hour of get up: ");
string getUpTime = hour switch
{
	>= 0 and < 6 => "night",
	>= 6 and < 12 => "morning",
	>= 12 and < 18 => "afternoon",
	>= 18 and < 24 => "evening",
	_ => "Invalid hour",
};

Console.WriteLine($"You get up in the {getUpTime}");

if (hour >= 0 && hour < 6)
{
	Console.ForegroundColor = ConsoleColor.Magenta;
	Console.WriteLine("You get up in the night");
}
else if (hour >= 6 && hour < 12)
{
	Console.ForegroundColor = ConsoleColor.Blue;
	Console.WriteLine("You get up in the morning");
}
else if (hour >= 12 && hour < 18)
{
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine("You get up in the afternoon");
}
else if (hour >= 18 && hour < 24)
{
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("You get up in the evening");
}
else
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine("Invalid hour");
}
Console.ResetColor();

// 3.2

const string PASSWORD = "password", MELLON = "Mellon", HACKED = "01101001 01101110";
string pass = string.Empty;
ConsoleKey key;
do
{
	var keyInfo = Console.ReadKey(intercept: true);
	key = keyInfo.Key;

	if (key == ConsoleKey.Backspace && pass.Length > 0)
	{
		Console.Write("\b \b");
		pass = pass[0..^1];
	}
	else if (!char.IsControl(keyInfo.KeyChar))
	{
		Console.Write("*");
		pass += keyInfo.KeyChar;
	}
}
while (key != ConsoleKey.Enter);

if (pass == PASSWORD)
{
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine("\nAccess granted");
}
else if (pass == MELLON)
{
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("\nWelcome, friend");
}
else if (pass == HACKED)
{
	Console.ForegroundColor = ConsoleColor.DarkRed;
	Console.WriteLine("\nHacked");
}
else
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine("\nAccess denied");
}
Console.WriteLine(pass);
Console.ResetColor();

// 4

int age = GetNumber(x => x > 0, "Enter your age: ");
string ageDescription = age switch
{
	 < 18 => "a minor",
	>= 18 and < 65 => "an adult",
	>= 65 => "eligible for the Senior Citizen promotion",
};
Console.WriteLine($"You are {ageDescription}");

if (age < 18)
	Console.WriteLine("You are a minor");
else if (age >= 18 && age < 65)
	Console.WriteLine("You are an adult");
else if (age >= 65)
	Console.WriteLine("You are eligible for the Senior Citizen promotion");

// 5

int year = GetNumber(x => x > 0, "Enter a year: ");

if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
	Console.WriteLine("The year is a leap year");
else
	Console.WriteLine("The year is not a leap year");

// 6

number = GetNumber();
if (number % 3 == 0 && number % 5 == 0)
    Console.WriteLine("BazingaPop");
else if (number % 3 == 0)
	Console.WriteLine("Bazinga");
else if (number % 5 == 0)
	Console.WriteLine("Pop");
else
	Console.WriteLine($"Nothing {number}");

// 7.1

int a = GetNumber();
int b = GetNumber();

if (a > 0 && b > 0)
    Console.WriteLine("Both numbers are positive");
else if (a > 0 && b <= 0 || a <= 0 && b > 0)
	Console.WriteLine("One of the numbers is positive");
else
	Console.WriteLine("Neither number is positive");

// 7.2

a = GetNumber();
b = GetNumber();
int c = GetNumber();

if (a == b && b == c)
	Console.WriteLine("All numbers are equal");
else if (a == b || b == c || a == c)
	Console.WriteLine("Two numbers are equal");
else
	Console.WriteLine("All numbers are different");

// 8.1

a = GetNumber();
b = GetNumber();
c = GetNumber();

if (a > 0 && b > 0 || a > 0 && c > 0 || b > 0 && c > 0)
	Console.WriteLine(a + b + c);
else
	Console.WriteLine("Could not calculate sum");

//8.2

year = GetNumber(x => x > 0, "Enter a year: ");
int month = GetNumber(x => x is >= 1 and <= 12, "Enter a month: ");

if (month is 1 or 2 or 3)
    Console.WriteLine("Cold pperiod");
else if (month is 6 or 7 or 8)
	Console.WriteLine("Hot period");
else
	Console.WriteLine("Medium period month");

// 9

a = GetNumber();
b = GetNumber();
c = GetNumber();

if (a + b > c && a + c > b && b + c > a)
	Console.WriteLine("Triangle can be built");
else
	Console.WriteLine("Triangle cannot be built");

// 10

Console.WriteLine(
@"
1. Milk - 1.5
2. Bread - 1.2
3. Butter - 2.5
");

int product1 = GetNumber(x => x is >= 1 and <= 3, "Enter a product 1: ");
int product2 = GetNumber(x => x is >= 1 and <= 3, "Enter a product 2: ");
double price = 0;

if (product1 == 1)
	price += 1.5;
else if (product1 == 2)
	price += 1.2;
else if (product1 == 3)
	price += 2.5;

if (product2 == 1)
	price += 1.5;
else if (product2 == 2)
	price += 1.2;
else if (product2 == 3)
	price += 2.5;

int card = GetNumber(x => x is >= 0 and <= 1, "Do you have card 1 - Yes, 0 - No: ");
if (card == 1)
	price *= 0.9;

Console.WriteLine($"Price is {price}");

// 11
// tick tack toe
char[,] map = new char[3, 3] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };

void PrintMap(char[,] map)
{
	Console.WriteLine($"\n{map[0, 1]} | {map[0, 1]} | {map[0, 2]}");
	Console.WriteLine("---------");
	Console.WriteLine($"{map[1, 0]} | {map[1, 1]} | {map[1, 2]}");
	Console.WriteLine("---------");
	Console.WriteLine($"{map[2, 0]} | {map[2, 1]} | {map[2, 2]}\n");
}

while (true)
{
	Console.WriteLine("Player 1");
	int x = GetNumber(x => x is >= 0 and <= 2, "Enter x: ");
	int y = GetNumber(x => x is >= 0 and <= 2, "Enter y: ");
	map[x, y] = 'X';
	PrintMap(map);

	Console.WriteLine("Player 2");
	x = GetNumber(x => x is >= 0 and <= 2, "Enter x: ");
	y = GetNumber(x => x is >= 0 and <= 2, "Enter y: ");
	map[x, y] = 'O';
	PrintMap(map);
}