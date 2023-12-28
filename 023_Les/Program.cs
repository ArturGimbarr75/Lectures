// 1_1-3 2_1-3
using System.Collections;

{
	Validation.Validate("sdgsd");
	Validation.Validate(55);
	Validation.Validate(new object());
	try
	{
		Validation.Validate<object>(null);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}

Console.WriteLine();

// 3_1-3
{
	Validation.ShowValues(1, "sdf");
	Validation.ShowValues("sdf", 1);
	Validation.ShowValues(1, 2);
	Validation.ShowValues("sdf", "sdf");
	Validation.ShowValues(1, 2.5);
	Validation.ShowValues(1.5, 2);
	Validation.ShowValues(1.5, 2.5);
	Validation.ShowValues(1.5, "sdf");
	Validation.ShowValues("sdf", 2.5);
}

Console.WriteLine();

// 4
{
	MySelfCreatedList<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    Console.WriteLine(string.Join(", ", list));

    Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(10);
    Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");

	int sum = 0;
	foreach (var item in list)
		sum += item;
	Console.WriteLine($"Sum: {sum}");

	list.RemoveAt(5);
	Console.WriteLine(string.Join(", ", list));
}

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

class MySelfCreatedList<T> : IEnumerable<T>
{
	public int Count { get; private set; }
	public int Capacity => _items.Length;

	private T[] _items;

	private const int DEFAULT_CAPACITY = 10; 

	public MySelfCreatedList()
	{
		Count = 0;
		_items = new T[DEFAULT_CAPACITY];
	}

	public T this[int i]
	{
		get
		{
			if (i < 0 || i >= Count)
				throw new ArgumentOutOfRangeException(nameof(i), "Index out of range");
			return _items[i];
		}
		set
		{
			if (i < 0 || i >= Count)
				throw new ArgumentOutOfRangeException(nameof(i), "Index out of range");
			_items[i] = value;
		}
	}

	public void Add(T item)
	{
		if (Count == Capacity)
		{
			var newItems = new T[Capacity * 2];
			Array.Copy(_items, newItems, Capacity);
			_items = newItems;
		}

		_items[Count++] = item;
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= Count)
			throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");

		for (int i = index; i < Count - 1; i++)
			_items[i] = _items[i + 1];

		Count--;
	}

	public void Clear()
	{
		Count = 0;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Count; i++)
			yield return _items[i];
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
