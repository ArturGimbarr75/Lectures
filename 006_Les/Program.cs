using _006_Les;

// Task1_1();
// Task1_2();
// Task1_3();

// Task2_1();
// Task2_2();
// Task2_3();

// Task3_1();
// Task3_2();
// Task3_3();

// Task4_1();
// Task4_2();

// Task5_1();
// Task5_2();
//Task5_3();

Project();

static void Task1_1()
{
	Console.WriteLine(nameof(Task1_1));
	int start = 1;
	int end = 5;
	int it = start;
	while (it <= end)
		Console.Write($"{it++} ");
    Console.WriteLine();
	it = end + 1;
	while (it --> start)
		Console.Write($"{it} ");
	Console.WriteLine();
}

static void Task1_2()
{
	Console.WriteLine(nameof(Task1_2));
	int start = 1;
	int end = 10;
	int it = start;

	while (it <= end)
		if (it % 2 == 0)
			Console.Write($"{it++} ");
		else
			it++;
	Console.WriteLine();

	it = start;
	while (it <= end)
		if (it % 2 == 1)
			Console.Write($"{it++} ");
		else
			it++;
	Console.WriteLine();
}

static void Task1_3()
{
	Console.WriteLine(nameof(Task1_3));
	int num = int.Parse(Console.ReadLine());

	while (num <= 100)
		num = int.Parse(Console.ReadLine());

	num = int.Parse(Console.ReadLine());
	while (num > 0)
		num = int.Parse(Console.ReadLine());
}

static void Task2_1()
{
	Console.WriteLine(nameof(Task2_1));
	uint num = uint.Parse(Console.ReadLine());
	ulong fact = num;
	while (0 <-- num)
		fact *= num;
	Console.WriteLine(fact);

	uint num2 = uint.Parse(Console.ReadLine());
	while (num2 > 0)
	{
		num = num2;
		fact = num;
		while (0 <-- num)
			fact *= num;
		Console.WriteLine(fact);
		num2 = uint.Parse(Console.ReadLine());
	}
}

static void Task2_2()
{
	Console.WriteLine(nameof(Task2_2));
	string num = Console.ReadLine();
	Console.WriteLine(string.Join(", ", num.ToCharArray()));
	int length = -1;
	while (num.Length - 1 >++ length)
		Console.Write($"{num[length]}, ");
	Console.WriteLine(num[^1]);
}

static void Task2_3()
{
	Console.WriteLine(nameof(Task2_3));
	int num = int.Parse(Console.ReadLine());
	int i = 0;
	while (num >=++ i)
		Console.WriteLine(new string('*', i));
	
}

static void Task3_1()
{
	Console.WriteLine(nameof(Task3_1));
	Console.Write("Enter number: ");
	string num = Console.ReadLine();
	while (!int.TryParse(num, out var _))
	{
		Console.Write("Incorrect number\nWrite one more time: ");
		num = Console.ReadLine();
	}
	Console.WriteLine($"Your number is {num}");
}

static void Task3_2()
{
	Console.WriteLine(nameof(Task3_2));
	Console.Write("Enter number: ");
	int num = int.Parse(Console.ReadLine());
	Console.Write("Enter degree: ");
	int degree = int.Parse(Console.ReadLine());
	int d = degree;
	int result = 1;
	while (degree --> 0)
		result *= num;
	Console.WriteLine($"{num}^{d} = {result}");
}

static void Task3_3()
{
	Console.WriteLine(nameof(Task3_3));
	Console.Write("Enter number: ");
	string num = Console.ReadLine();
	int n;
	while (!int.TryParse(num, out n))
	{
		Console.Write("Incorrect number\nWrite one more time: ");
		num = Console.ReadLine();
	}
	int i = 0;
	while (n >=++ i)
		if (n == i)
			Console.WriteLine(new string('1', i));
		else
			Console.Write(new string('1', i) + " -> ");

}

static void Task4_1()
{
    Console.WriteLine(nameof(Task4_1));
	Console.Write("Enter number: ");
	int num = int.Parse(Console.ReadLine());
	int i = 0;
	while (num >=++ i)
	{
		int tempI = i;
		while (tempI --> 0)
			Console.Write(i);
        Console.WriteLine();
    }
}

static void Task4_2()
{
	Console.WriteLine(nameof(Task4_2));
	Console.Write("Enter euro amount: ");
	int amount = int.Parse(Console.ReadLine());
	Console.Write("ATM withdraw: ");
	while (amount > 0)
	{
		string print = amount switch
		{
			>= 500 => "Є500, ",
			>= 200 => "Є200, ",
			>= 100 => "Є100, ",
			>= 50 => "Є50, ",
			>= 20 => "Є20, ",
			>= 10 => "Є10, ",
			>= 5 => "Є5, ",
			>= 2 => "Є2, ",
			>= 1 => "Є1"
		};
		amount -= int.Parse(print.Replace("Є", "").Replace(", ", ""));
		Console.Write(print);
	}
}

static void Task5_1()
{
	Console.WriteLine(nameof(Task5_1));
	string? input;
	int sum = 0;
	do
	{
		Console.Write("Enter number or 'Finish': ");
		input = Console.ReadLine();
		if (int.TryParse(input, out var num))
			sum += num;
		else if (input != "Finish")
			Console.WriteLine("Incorrect input");
	}
	while (input != "Finish");

	Console.WriteLine($"Sum = {sum}");
}

static void Task5_2()
{
	Console.WriteLine(nameof(Task5_2));
	const string PASSWORD = "12345";
	string pass = string.Empty;
	ConsoleKey key;
	while (true)
	{
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
			Console.WriteLine("\nAccess granted");
			break;
		}
		else
		{
			Console.WriteLine("\nAccess denied");
			pass = string.Empty;
		}
	}
}

static void Task5_3()
{
	Console.WriteLine(nameof(Task5_3));
	int randNum = Random.Shared.Next(1, 101);
	int guess;
    Console.WriteLine("Guess numberr between 1-100: ");
    do
	{
		guess = int.Parse(Console.ReadLine());
		if (guess > randNum)
			Console.WriteLine("Too high");
		else if (guess < randNum)
			Console.WriteLine("Too low");
		else
			Console.WriteLine("Correct");
	}
	while (guess != randNum);
}

static void Project()
{
	Snake snake = new(50, 20);
	snake.Print();
	Direction direction = Direction.Right;
	Task.Run(() =>
	{
		while (true)
		{
			Thread.Sleep(100);
			snake.Move(direction);
			snake.Print();
		}
	});
	while (true)
	{
		ConsoleKey key = Console.ReadKey(intercept: true).Key;

		direction = key switch
		{
			ConsoleKey.UpArrow => Direction.Up,
			ConsoleKey.DownArrow => Direction.Down,
			ConsoleKey.LeftArrow => Direction.Left,
			ConsoleKey.RightArrow => Direction.Right,
			_ => direction,
		};
	}
}