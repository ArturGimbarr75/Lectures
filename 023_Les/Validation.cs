// 1_1-3 2_1-3
static class Validation
{
	public static void Validate<T>(T? value)
	{
		if (value is null)
			throw new ArgumentNullException(nameof(value), "Value is null");
		Console.WriteLine($"Value '{value}' not null");
    }

	public static void ShowValues<T1, T2>(T1 value1, T2 value2)
	{
        Console.WriteLine("Value1: {0}, Value2: {1}", value1, value2);
    }
}
