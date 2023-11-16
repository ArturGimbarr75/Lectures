// Task 1
{
	int a = 1, b = 2;
	Console.WriteLine($"a = {a}, b = {b}");
	Task1.Swap(ref a, ref b);
	Console.WriteLine($"a = {a}, b = {b}");

	double d1 = 1.0, d2 = 2.0;
    Console.WriteLine($"d1 = {d1}, d2 = {d2}");
	Task1.Add(ref d1, d2);
	Console.WriteLine($"d1 = {d1}, d2 = {d2}");

	string s = "  Hello, World!  ";
	Console.WriteLine($"s = \"{s}\"");
	Task1.TrimAndCapitalize(ref s);
	Console.WriteLine($"s = \"{s}\"");
}

// Task2
{
	Task2.GetUserData(out string name, out string surname);
	Console.WriteLine($"Hello, {name} {surname}!");

	int num = 0;
	do
	{
		Console.Write("Enter a number less than 100: ");

	}
	while (!int.TryParse(Console.ReadLine(), out num) || num >= 100);

	double number = 5;
	double divider = 0;
	if (Task2.TryDivide(number, divider, out double result))
	{
		Console.WriteLine($"{number} / {divider} = {result}");
	}
	else
	{
		Console.WriteLine($"Cannot divide {number} by {divider}");
	}
}
