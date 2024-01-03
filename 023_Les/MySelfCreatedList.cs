// 1_1-3 2_1-3
using System.Collections;

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
