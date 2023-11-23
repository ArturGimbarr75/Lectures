// Task 1
{
	for (int i = 0; i < 100; Console.Write($"{i += 2} "));
	Console.WriteLine();
}

// Task 2
{
	int sum = 0;
	for (int i = 1, n = int.Parse(Console.ReadLine()!); i <= n; sum += i++);
	Console.WriteLine(sum);
}

// Task 3
for (int i = 1, n = int.Parse(Console.ReadLine()!); i <= n; Console.Write($"{i * i++}, ")) ;
Console.WriteLine();

// Task 4
{
	int n = int.Parse(Console.ReadLine()!);
	double sum = 0;
	for (int i = 1; i <= n; sum += i++);
	Console.WriteLine($"{sum / n:0.00}");
}

// Task 5
for (int i = 1, n = int.Parse(Console.ReadLine()!); i <= n; i++, Console.WriteLine("*"));

// Task 6
for (int i = 0; i < 100; Console.Write($"{i}, "), i += 3) ;
