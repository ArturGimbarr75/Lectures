using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
/*
// Task 1
{
	int a = 10;
	int b = 5;
	int c = 8;

	int max = a;
	if (b > max)
		max = b;
	if (c > max)
		max = c;

    Console.WriteLine($"The maximum value is: {max}");
}

// Task 2
{
	string firstName = "John";
	string lastName = "Doe";
	string fullName = firstName + " " + lastName;
    Console.WriteLine($"Full name is {fullName}");
}

// Task 3
{
	int a = 1;
	while (a <= 10)
	{
		Console.WriteLine(a);
		a++;
	}
}

// Task 4
{
	int i = 1;
	while (i <= 5)
	{ 
		Console.WriteLine(i);
		i++;
	}
}

// Task 5
{
	string name1 = "John";
	string name2 = "john";

	if (name1 == name2)
		Console.WriteLine("The names are the same");
	else
		Console.WriteLine("The names are not the same");
}*/

const int ITERATIONS = 1000000;
double[] CompareFunctionsTime(params Action[] functions)
{
	var results = new double[functions.Length];

	for (int i = 0; i < functions.Length; i++)
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int j = 0; j < ITERATIONS; j++)
			functions[i]();
		stopwatch.Stop();
		results[i] = (double)stopwatch.ElapsedMilliseconds / (ITERATIONS / 1000);
	}

	return results;
}

// Task 6
{
	string str = "Some string to revert with different functions";

	void LinqRevert()
	{
		string res = new(str.Reverse().ToArray());
	}

	void LoopRevert()
	{
		string res = "";
		for (int i = str.Length - 1; i >= 0; i--)
			res += str[i];
	}

	void RegexRevert()
	{
		string res = Regex.Replace(str, ".",
						m => str[str.Length - m.Index - 1].ToString());
	}

	void StringBuilderRevert()
	{
		var sb = new StringBuilder();
		for (int i = str.Length - 1; i >= 0; i--)
			sb.Append(str[i]);
		string res = sb.ToString();
	}

	double[] results = CompareFunctionsTime(LinqRevert, LoopRevert, RegexRevert, StringBuilderRevert);
	string[] names = new string[] { "Linq", "Loop", "Regex", "StringBuilder" };
	foreach (var (res, name) in results.Zip(names))
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write(name.PadLeft(13));
		Console.ResetColor();
		Console.Write(" mean time: ");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write($"{res:0.000} mu");
		Console.ResetColor();
		Console.Write("; Full time: ");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine($"{res * ITERATIONS / 1000:0.000000} ms");
		Console.ResetColor();
	}
}