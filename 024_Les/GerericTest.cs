// 1
class GerericTest<T1, T2>
{
	private T1 _property1;
	private T2 _property2;

	public GerericTest(T1 property1, T2 property2)
	{
		_property1 = property1;
		_property2 = property2;
	}

	public void PrintProperty1()
	{
		Console.WriteLine(_property1);
	}

	public void PrintProperty2()
	{
        Console.WriteLine(_property2);
    }

	public void SetProperty1(T1 value)
	{
		_property1 = value;
	}

	public void SetProperty2(T2 value)
	{
		_property2 = value;
	}
}