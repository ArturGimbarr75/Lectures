static class Task2
{
	public static string GetFullName(string firstName, string lastName)
	{
		return $"{lastName} {firstName}";
	}

	public static double CalculateCylinderVolume(double radius, double height)
	{
		return Math.PI * Math.Pow(radius, 2) * height;
	}

	public static bool IsEven(int number)
	{
		return number % 2 == 0;
	}

	public static double CalculateRectangleArea(double width, double height)
	{
		return width * height;
	}
}