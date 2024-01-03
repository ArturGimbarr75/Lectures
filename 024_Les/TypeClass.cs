// 1

// 2

// 3
public class TypeClass<T>
{
	private T _firstVariable;
	private T _secondVariable;

	public TypeClass(T first, T second)
	{
		_firstVariable = first;
		_secondVariable = second;
	}

	public void PrintType(T input)
	{
		Console.WriteLine($"The type of the input variable is: {input?.GetType()}");
	}
}
