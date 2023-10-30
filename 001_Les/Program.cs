string triangle =
"""
   /\
  /  \
 /    \
/______\
""";

string circle =
"""
     *****
   **     **
 **         **
**   Hello   **
**    from   **
 **   C#    **
   **     **
     *****
""";

string heart =
"""
 /\     /\
/  \   /  \
\   \ /   /
 \   V   /
  \     /
   \   /
    \ /
     V
""";

ConsoleColor[] triangleColors = new int[] { 14, 10, 12, 13 }.Cast<ConsoleColor>().ToArray();
ConsoleColor[] heartColors = new int[] { 1, 9, 11, 14, 13, 12, 4, 10 }.Cast<ConsoleColor>().ToArray();

Console.WriteLine($"{triangle}\n\n{circle}\n");
foreach (var (l, c) in triangle.Split("\n").Zip(triangleColors))
{
	Console.ForegroundColor = c;
	Console.WriteLine(l);
}
Console.WriteLine("\n");
foreach (var (l, c) in heart.Split("\n").Zip(heartColors))
{
	Console.ForegroundColor = c;
	Console.WriteLine(l);
}

ColorConsole.WriteLine("\nGood: Apple\nCount: 5\nPrice: 2 EU\n");

int age = 28;
ColorConsole.WriteLine(
	$"""
	Name: Some Name and Surname
	Age: {age}
	Work: Softare Developer
	Email: name.surname@gmail.com
	Phone: +1 123-456-7890
	""", true);

Console.ResetColor();
