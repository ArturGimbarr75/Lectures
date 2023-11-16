using System.Numerics;

static class Task1
{
	public static void Swap<T> (ref T a, ref T b) => (a, b) = (b, a);

	public static void Add<T> (ref T a, T b) where T : IAdditionOperators<T, T, T>
	{
		a += b;
	}

	public static void TrimAndCapitalize(ref string s)
	{
		s = s.Trim().ToUpper();
	}
}