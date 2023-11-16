static class Task3
{
	public static int Factorial(int number)
	{
		return number == 0 ? 1 : number * Factorial(number - 1);
	}

	public static int Fibonacci(int number)
	{
		return number switch
		{
			0 => 0,
			1 => 1,
			_ => Fibonacci(number - 1) + Fibonacci(number - 2)
		};
	}
}
