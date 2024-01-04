using System.Collections.Immutable;

class GenericClass<T>
{
	ImmutableList<T> _list;

    public GenericClass()
    {
        _list = ImmutableList<T>.Empty;
    }

    public GenericClass(params T[] values) : this(values as IEnumerable<T>) { }

	public GenericClass(IEnumerable<T> values) : this()
	{
		_list = _list.AddRange(values);
	}

	public void Print()
	{
        Console.WriteLine("List:");
        foreach (var item in _list)
		{
            Console.Write("\t");
            Console.WriteLine(item);
		}
	}

	public T[] ToArray()
	{
		return _list.ToArray();
	}

	public T Find(Func<T, bool> match)
	{
		bool found = false;
		T result = default!;

		foreach (var item in _list)
		{
			if (match(item))
			{
				if (found)
					throw new Exception("More than one item found");

				found = true;
				result = item;
			}
		}

		return found ? throw new Exception("Item not found") : result;
	}

	public T FindOrDefault(Func<T, bool> match)
	{
		bool found = false;
		T result = default!;

		foreach (var item in _list)
		{
			if (match(item))
			{
				if (found)
					throw new Exception("More than one item found");

				found = true;
				result = item;
			}
		}

		return default!;
	}

	public bool Exists(T value)
	{
		return _list.Contains(value);
	}
}
