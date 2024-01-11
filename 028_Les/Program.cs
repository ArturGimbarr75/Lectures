// 1
using System.Collections.Immutable;

{
	string Concat(string name, string surname, int age)
	{
		return $"{name} {surname} is {age} years old.";
	}

	Func<string, string, int, string> func = Concat;

	Console.WriteLine(func("John", "Doe", 30));
}

// 2
{
	int Sum(int a, int b)
	{
		return a + b;
	}

	Func<int, int, int> func = Sum;

	Console.WriteLine(func(1, 2));
}

// 3
{
	List<int> Iter(List<int> list, int step)
	{
		var result = new List<int>();
		for (int i = 0; i < list.Count; i += step)
		{
			result.Add(list[i]);
		}
		return result;
	}

	var func = Iter;
	Console.WriteLine(string.Join(", ", func([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 3)));
}

// 4
{
	List<int> Iter(List<int> list, int step)
	{
		var result = new List<int>();
		for (int i = 0; i < list.Count; i += step)
		{
			result.Add(list[i]);
		}
		return result;
	}

	Func<List<int>, int, List<int>> func = Iter;
	Console.WriteLine(string.Join(", ", func([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 3)));
}

// 5
{
	Func<Type> func = 4.GetType;
	Console.WriteLine(func());
}

// 6
{
	List<Person> people = new()
	{
		new() { Name = "John", Age = 30 },
		new() { Name = "Jane", Age = 25 },
		new() { Name = "Jack", Age = 40 },
		new() { Name = "Jill", Age = 35 },
	};

	Func<Person, bool> filrter1 = p => p.Age > 30;
	Func<Person, bool> filrter2 = p => p.Name.StartsWith("J");
	Func<Person, bool> filrter3 = p => p.Name.Length > 3;

	void PrintPeople(List<Person> people, Func<Person, bool> filter)
	{
        Console.WriteLine("\n----------------------------------\n");
		foreach (var person in people)
		{
			if (filter(person))
				Console.WriteLine($"{person.Name} is {person.Age} years old.");
		}
    }

	PrintPeople(people, filrter1);
	PrintPeople(people, filrter2);
	PrintPeople(people, filrter3);
}

class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}