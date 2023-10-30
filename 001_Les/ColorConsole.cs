using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Les;

internal static class ColorConsole
{
	private static ConsoleColor[] _colors;
	private static int _index = 0;

	static ColorConsole()
	{
		_colors = Enum.GetValues(typeof(ConsoleColor))
						.Cast<ConsoleColor>()
						.Where(c => c != Console.BackgroundColor)
						.ToArray();
	}

	public static void WriteLine(string text, bool separateByChar = false)
	{
		if (separateByChar)
		{
			foreach (var c in text)
			{
				Console.ForegroundColor = NextColor();
				Console.Write(c);
			}
            Console.WriteLine();
        }
		else
			foreach (var line in text.Split("\n"))
			{
				Console.ForegroundColor = NextColor();
				Console.WriteLine(line);
			}
	}

	public static void Write(string text, bool separateByChar = false)
	{
		if (separateByChar)
			foreach (var c in text)
			{
				Console.ForegroundColor = NextColor();
				Console.Write(c);
			}
		else
			foreach (var line in text.Split("\n"))
			{
				Console.ForegroundColor = NextColor();
				Console.Write(line);
			}
	}

	private static ConsoleColor NextColor()
	{
		if (_index >= _colors.Length)
		{
			_index = 0;
		}

		return _colors[_index++];
	}
}
