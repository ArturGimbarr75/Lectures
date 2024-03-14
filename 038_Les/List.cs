using System.Collections;

namespace CustomCollections.Generic;

public class List<T> : IList<T>
{
	public int Count { get; private set; }

	public int Capacity => _items.Length;

	public bool IsReadOnly => false;

	private T[] _items;

	public List()
	{
		_items = new T[4];
	}

    public List(int capacity)
    {
        if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(capacity));
		}

		_items = new T[capacity];
    }

    public List(IEnumerable<T> collection)
    {
        if (collection == null)
			throw new ArgumentNullException(nameof(collection));

		if (collection is ICollection<T> c)
		{
			_items = new T[c.Count];
			c.CopyTo(_items, 0);
			Count = c.Count;
		}
		else
		{
			_items = new T[4];
			foreach (T item in collection)
			{
				Add(item);
			}
		}
    }

    public T this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			return _items[index];
		}
		set
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			_items[index] = value;
		}
	}

	public void Add(T item)
	{
		if (Count == _items.Length)
		{
			T[] larger = new T[Count * 2];
			Array.Copy(_items, larger, Count);
			_items = larger;
		}

		_items[Count] = item;
		Count++;
	}

	public void AddRange(IEnumerable<T> collection)
	{
		if (collection == null)
			throw new ArgumentNullException(nameof(collection));

		if (collection is ICollection<T> c)
		{
			if (Count + c.Count > _items.Length)
			{
				T[] larger = new T[Count + c.Count];
				Array.Copy(_items, larger, Count);
				_items = larger;
			}

			c.CopyTo(_items, Count);
			Count += c.Count;
		}
		else
		{
			foreach (T item in collection)
			{
				Add(item);
			}
		}
	}

	public int IndexOf(T item)
	{
		int index = -1;

		for (int i = 0; i < Count; i++)
		{
			if (EqualityComparer<T>.Default.Equals(_items[i], item))
			{
				index = i;
				break;
			}	
		}

		return index;
	}

	public void Insert(int index, T item)
	{
		if (index < 0 || index > Count)
		{
			throw new IndexOutOfRangeException();
		}

		if (Count == _items.Length)
		{
			T[] larger = new T[Count * 2];
			Array.Copy(_items, larger, Count);
			_items = larger;
		}

		Array.Copy(_items, index, _items, index + 1, Count - index);

		_items[index] = item;
		Count++;
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}

		Array.Copy(_items, index + 1, _items, index, Count - index - 1);
		Count--;
	}

	public void Clear()
	{
		if (Count > 0)
		{
			Array.Clear(_items, 0, Count);
			Count = 0;
		}
	}

	public bool Contains(T item)
	{
		for (int i = 0; i < Count; i++)
		{
			if (EqualityComparer<T>.Default.Equals(_items[i], item))
			{
				return true;
			}
		}

		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Array.Copy(_items, 0, array, arrayIndex, Count);
	}

	public bool Remove(T item)
	{
		for (int i = 0; i < Count; i++)
		{
			if (EqualityComparer<T>.Default.Equals(_items[i], item))
			{
				Array.Copy(_items, i + 1, _items, i, Count - i - 1);
				Count--;
				return true;
			}
		}

		return false;
	}
	
	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Count; i++)
		{
			yield return _items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}