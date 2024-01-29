// CheckProgress();
CheckDesctop();

void CheckProgress()
{
	Console.Write("Write count of works: ");
	int count = int.Parse(Console.ReadLine()!);
	Console.Write("Write length of progress bar: ");
	int length = int.Parse(Console.ReadLine()!);

	Task[] works = new Task[count];
	for (int i = 0; i < count; i++)
	{
		int skipLines = 1 + count + 1;
		lock (Console.Out)
		{
			Console.SetCursorPosition(0, i + 2);
			Console.WriteLine($"Work {i + 1,3}:");
		}

		ProgressBar progressBar = new(i + 2, 10, length);
		Work work = new(progressBar, Random.Shared.NextSingle() + 0.05f);
		works[i] = work.DoWorkAsync();
	}

	Task.WaitAll(works);
	Console.SetCursorPosition(0, count + 2);
	Console.WriteLine("\nAll done!");
}

void CheckDesctop()
{
	PrintDesctopDirectory();
	while (true);
}

async Task PrintDesctopDirectory()
{
	string path = Path.Combine(Environment.ProcessPath!.Split("\\")[..^1]);

	while (true)
	{
		Console.WriteLine($"Directory: {path}");

		Console.WriteLine("Files:");
		foreach (string file in Directory.EnumerateFiles(path))
			Console.WriteLine($"\t{file.Split("\\")[^1]}");

		Console.WriteLine("Directories:");
		foreach (string directory in Directory.EnumerateDirectories(path))
			Console.WriteLine($"\t{directory.Split("\\")[^1]}");
		await Task.Delay(5000);
		Console.Clear();
	}
}