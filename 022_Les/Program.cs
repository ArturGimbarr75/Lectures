// 1_1
using System.Diagnostics;
using System.Text;

{
    Console.WriteLine("1_1");
    Console.WriteLine(File.ReadAllText("data.txt"));
    Console.WriteLine();
}

// 1_2
{
	List<string> lines = ["Hello", "World"];
    File.WriteAllLines("data2.txt", lines);
}

// 1_3
{
    string randPath = Path.GetRandomFileName();
	File.Copy("data.txt", $"dataCopy{randPath}.txt");
}

// 2_1
{
    IEnumerable<string> lines = File.ReadLines("BigFile.txt");
    List<int> charCount = new(1000000);
    foreach (string line in lines)
        charCount.Add(line.Length);
}

// 2_2
{
	using StreamWriter writer = new("NumsAndText.txt");
	
    for (int i = 0, count = Random.Shared.Next(500, 2000); i < count; i++)
    writer.WriteLine(Random.Shared.Next(0, 1000) + Path.GetRandomFileName());
}

// 2_3
{
    using Stream wStream = File.OpenWrite("Vector3.bin");
    using BinaryWriter bWriter = new(wStream);
    Vector3 wVector = new(1, 2, 3);
    bWriter.Write(wVector.ToByteArray());
    bWriter.Dispose();
    wStream.Dispose();

    using Stream rStream = File.OpenRead("Vector3.bin");
    using BinaryReader bReader = new(rStream);
    Vector3 rVector = Vector3.FromByteArray(bReader.ReadBytes(12));
    Console.WriteLine(rVector);
}

// 3_1
{
    Console.WriteLine("3_1");
    Stopwatch stopwatch = new();
    FileStream reader = new("BigFile.txt", FileMode.Open, FileAccess.Read, FileShare.None, 4096);
    List<byte> bytes = new();
    int buffer;

    stopwatch.Start();
    while ((buffer = reader.ReadByte()) != -1)
        bytes.Add((byte)buffer);

    stopwatch.Stop();
    Console.Write("FileStream: ");
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
	reader.Dispose();

    stopwatch.Restart();
    bytes.Clear();
    string text = File.ReadAllText("BigFile.txt");
    bytes.AddRange(Encoding.UTF8.GetBytes(text));
    stopwatch.Stop();
    Console.Write("File.ReadAllText: ");
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
}

// 3_2
{
    // async reader
    Console.WriteLine("3_2");
    int linesCount = 0;

    IAsyncEnumerable<string> lines = File.ReadLinesAsync("BigFile.txt");
    IAsyncEnumerator<string> enumerator = lines.GetAsyncEnumerator();
    while (await enumerator.MoveNextAsync())
        linesCount++;
}

// 3_3
{
    FileStream fs = new("key-value.txt", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
    StreamWriter sw = new(fs);
    for (int i = 0; i < 100; i++)
		sw.WriteLine($"{i} {Random.Shared.Next(0, 1000)}");

    sw.Dispose();
	fs.Dispose();

	Dictionary<int, int> keyValue = new();
	using StreamReader sr = new("key-value.txt");
	while (!sr.EndOfStream)
    {
        string[] line = sr.ReadLine().Split(' ');
        keyValue.Add(int.Parse(line[0]), int.Parse(line[1]));
	}

    Console.WriteLine(keyValue[0]);
    Console.WriteLine(keyValue[1]);
    Console.WriteLine(keyValue[2]);
    Console.WriteLine(keyValue[3]);
    Console.WriteLine(keyValue[4]);
    Console.WriteLine(keyValue[5]);
    Console.WriteLine(keyValue[6]);
    Console.WriteLine(keyValue[7]);
    Console.WriteLine(keyValue[8]);
    Console.WriteLine(keyValue[9]);
}