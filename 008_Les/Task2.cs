// Task 1

// Task2
static class Task2
{
	public static void GetUserData(out string name, out string surname)
	{
		do
		{
			Console.Write("Enter your name: ");
			name = Console.ReadLine()!;
		}
		while (name is null);

		do
		{
            Console.Write("Enter you surname: ");
            surname = Console.ReadLine()!;
		}
		while (surname is null);
	}

	public static bool TryDivide(double num, double divider, out double result, out int remainder)
	{
		if (divider == 0)
		{
			result = 0;
			remainder = 0;
			return false;
		}
		else
		{
			result = num / divider;
			remainder = (int)num % (int)divider;
			return true;
		}
	}
}