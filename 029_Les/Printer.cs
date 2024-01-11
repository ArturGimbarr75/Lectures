static class Printer
{
	public static void Print<T>(this IEnumerable<T> data)
	{
		Console.WriteLine(string.Join(", ", data));
	}

	public static void Print<T>(this IEnumerable<T> data, Func<T, string> converter)
	{
		Console.WriteLine(string.Join(", ", data.Select(converter)));
	}
}

