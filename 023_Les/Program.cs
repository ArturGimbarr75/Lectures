// 1_1-3 2_1-3
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
