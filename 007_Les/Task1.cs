using System.Text.RegularExpressions;

static class Task1
{
	public static bool IsPasswordValid(string? password)
	{
		return password is { Length: >= 8 };
	}

	public static bool IsEmailValid(string? email)
	{
		if (email is null)
			return false;

		Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
		return regex.IsMatch(email);
	}

	public static double UsdToEu(double usd)
	{
		return usd * 0.85;
	}
}