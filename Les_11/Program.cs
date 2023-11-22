// Task 1.1
{
	int[] Square(params int[] ints) => ints.Select(i => i * i).ToArray();

    Console.WriteLine(string.Join(", ", Square(1, 2, 3, 4, 5, 6, 7, 8)));
}

// Task 1.2
{
	int Sum(params int[] ints) => ints.Sum();

	Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8));
}

// Task 1.3
{
	int Max(params int[] ints) => ints.Max();

	Console.WriteLine(Max(1, 2, 3, 4, 5, 6, 7, 8));
}

// Task 1.4
{
	void PrintReverse(params int[] ints) => Console.WriteLine(string.Join(", ", ints.Reverse()));

	PrintReverse(1, 2, 3, 4, 5, 6, 7, 8);
}

// Task 2.1
{
	char[] ToCharArray(string str) => str.ToCharArray();

	Console.WriteLine(string.Join(", ", ToCharArray("Hello World!")));
}

// Task 2.2
{
	char PrintFirstSentenceLetter(string str) => str.ToCharArray()[0];

	char f = PrintFirstSentenceLetter("Hello World.");
	Console.WriteLine(f);
}

// Task 2.3
{
	char LastLetter(string str) => str.ToCharArray()[^1];

	char l = LastLetter("Hello World.");
	Console.WriteLine(l);
}

// Task 3
void QuickSort(int[] arr, int left = -1, int right = -1, IComparer<int> comparer = null!)
{
	if (left == -1)
		left = 0;
	if (right == -1)
		right = arr.Length - 1;
	comparer ??= Comparer<int>.Default;

	int i = left, j = right;
	int pivot = arr[(left + right) / 2];

	while (i <= j)
	{
		while (comparer.Compare(arr[i], pivot) < 0)
			i++;

		while (comparer.Compare(arr[j], pivot) > 0)
			j--;

		if (i <= j)
		{
			(arr[j], arr[i]) = (arr[i], arr[j]);

			i++;
			j--;
		}
	}

	if (left < j)
		QuickSort(arr, left, j, comparer);

	if (i < right)
		QuickSort(arr, i, right, comparer);
}

// Task 3.1
{
	int[] arr = { 8, 1, 2, 4, 3, 5, 7, 6 };
	QuickSort(arr);
	Console.WriteLine(string.Join(", ", arr));
}

// Task 3.2
{
	int[] arr = { 8, 1, 2, 4, 3, 5, 7, 6 };
	QuickSort(arr, comparer: Comparer<int>.Create((x, y) => y.CompareTo(x)));
	Console.WriteLine(string.Join(", ", arr));
}

// Task 3.3
{
	int[] arr = { 8, 1, 2, 4, 3, 5, 7, 6 };
	int[] AddElement(int[] arr, int element) => arr.Append(9).ToArray();

	arr = AddElement(arr, 9);
	Console.WriteLine(string.Join(", ", arr));
}

// Task 3.4
{
	int[] arr = { 8, 1, 2, 4, 3, 5, 7, 6 };
	int[] RemoveElement(int[] arr, int element) => arr.Where(i => i != element).ToArray();

	arr = RemoveElement(arr, 8);
	Console.WriteLine(string.Join(", ", arr));
}