using System.Collections;

public class FileWriter : IFileWriteable
{
	Queue _pool = new();

	public void AppendPool(IEnumerable objects)
	{
		foreach (var obj in objects)
		{
			_pool.Enqueue(obj);
		}
	}

	public void WriteToFile(string path)
	{
		using StreamWriter writer = new(path, true);
		while (_pool.Count > 0)
			writer.WriteLine(_pool.Dequeue());
	}
}
