static class Comparer
{
	public static async Task CompareAsyncAndThread()
	{
		Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");

		Task[] tasks = Enumerable.Range(1, 9)
			.Select(i => Task.Run(async () =>
			{
				int top = i;
				int left = 0;

				lock (Console.Out)
				{
					Console.SetCursorPosition(left, top);
					Console.Write($"Task {i} thread id:");
					left = Console.CursorLeft;
				}

				for (int j = 0; j < 10; j++)
				{
					lock (Console.Out)
					{
						Console.SetCursorPosition(left, top);
						Console.Write($" {Thread.CurrentThread.ManagedThreadId,3}");
						left = Console.CursorLeft;
					}

					await Task.Delay(Random.Shared.Next(100, 500));
					//await Task.Delay(100);
				}
			}))
			.ToArray();

		await Task.WhenAll(tasks);
		Console.SetCursorPosition(0, 15);

		Thread[] threads = Enumerable.Range(1, 9)
			.Select(i => new Thread(() =>
			{
				int top = i + 10;
				int left = 0;

				lock (Console.Out)
				{
					Console.SetCursorPosition(left, top);
					Console.Write($"Thread {i} thread id:");
					left = Console.CursorLeft;
				}

				for (int j = 0; j < 10; j++)
				{
					lock (Console.Out)
					{
						Console.SetCursorPosition(left, top);
						Console.Write($" {Thread.CurrentThread.ManagedThreadId,3}");
						left = Console.CursorLeft;
					}

					Thread.Sleep(100);
				}
			}))
			.ToArray();

		foreach (Thread thread in threads)
			thread.Start();

		Thread.Sleep(3000);
		Console.SetCursorPosition(0, 25);
	}

	public static async Task CheckLock()
	{
		VarKeeper varKeeper = new();

		Task[] tasks = Enumerable.Range(1, 3)
			.Select(i => Task.Run(async () =>
			{
				for (int j = 0; j < 1000; j++)
				{
					//varKeeper.IncrementWithLock();
					varKeeper.IncrementWithoutLock();
                    Console.WriteLine(varKeeper);
					await Task.Delay(1000);
                }
			}))
			.ToArray();

		await Task.WhenAll(tasks);
	}
}
