class NumberHolder
{
	public int Count => _numbers.Count;

	private List<int> _numbers = new();

	public void Add(int number) => _numbers.Add(number);

	public void Print() => Console.WriteLine(string.Join(", ", _numbers));
}