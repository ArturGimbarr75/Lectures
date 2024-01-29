internal class ProgressBar
{
	private int _val;

	private readonly int _pos;
	private readonly int _len;

	private readonly int _top;
	private readonly int _left;
	private readonly int _width;

    public ProgressBar(int top, int left, int width)
    {
        _left = left;
        _top = top;
        _width = width;

		_pos = _left + 1;
		_len = _width - 1;
		_val = 1;

		lock (Console.Out)
		{
			Console.SetCursorPosition(_left, _top);
			Console.Write("[");
			Console.SetCursorPosition(_left + _width, _top);
			Console.Write("]");
		}
	}

    public void Draw(int progress)
    {
		progress = Math.Max(0, Math.Min(100, progress));

		int val = (int)Math.Round(progress / 100.0 * _len);

		if (val == _val)
			return;

		_val = val;
		lock (Console.Out)
		{
			Console.SetCursorPosition(_pos, _top);
			Console.Write(new string('#', val));

			if (_val == _len)
				Console.WriteLine("] Done!");
		}
	}
}
