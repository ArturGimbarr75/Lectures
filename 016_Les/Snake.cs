public class Snake
{
	public readonly (int X, int Y) BoardSize;

	private List<(int X, int Y)> _snake;
	private (int X, int Y) _food;
	private (int X, int Y) _partToRemove;

	public Snake(int boardX = 10, int boardY = 10)
	{
		BoardSize = (boardX, boardY);
		_snake = new List<(int X, int Y)>() { (boardX / 2, boardY / 2) };
		_snake.Add((_snake[0].X - 1, _snake[0].Y));
		_snake.Add((_snake[0].X - 2, _snake[0].Y));
		_partToRemove = _snake[^1];
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Red;
		for (int y = 0; y < BoardSize.Y; y++)
			for (int x = 0; x < BoardSize.X; x++)
				if (x == 0 || x == BoardSize.X - 1 || y == 0 || y == BoardSize.Y - 1)
				{
					Console.SetCursorPosition(x, y);
					Console.Write("#");
				}
		Console.ResetColor();
		SpawnFood();
	}

	public void Move(Direction direction)
	{
		_partToRemove = _snake[^1];
		(int X, int Y) newPos = direction switch
		{
			Direction.Up => (_snake[0].X, _snake[0].Y - 1),
			Direction.Down => (_snake[0].X, _snake[0].Y + 1),
			Direction.Left => (_snake[0].X - 1, _snake[0].Y),
			Direction.Right => (_snake[0].X + 1, _snake[0].Y),
			_ => throw new NotImplementedException(),
		};

		if (newPos.X == _food.X && newPos.Y == _food.Y)
		{
			Grow();

			SpawnFood();
		}

		if (!(newPos.X == 0
			|| newPos.X == BoardSize.X - 1
			|| newPos.Y == 0
			|| newPos.Y == BoardSize.Y - 1
			|| _snake.Contains(newPos)))
		{
			for (int i = _snake.Count - 1; i > 0; i--)
				_snake[i] = _snake[i - 1];
			_snake[0] = newPos;
		}
	}

	private void SpawnFood()
	{
		do
		{
			_food = (Random.Shared.Next(1, BoardSize.X - 1), Random.Shared.Next(1, BoardSize.Y - 1));
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(_food.X, _food.Y);
			Console.Write("F");
			Console.ResetColor();
		}
		while (_snake.Contains(_food));
	}

	private void Grow()
	{
		_snake.Add((_snake[^1].X, _snake[^1].Y));
	}

	public void Print()
	{
		Console.SetCursorPosition(_partToRemove.X, _partToRemove.Y);
		Console.WriteLine(" ");
		Console.ForegroundColor = ConsoleColor.Green;
		var (x, y) = _snake[0];
		Console.SetCursorPosition(x, y);
		Console.Write("O");
		Console.ResetColor();
		Console.ForegroundColor = ConsoleColor.DarkGreen;
		(x, y) = _snake[^1];
		Console.SetCursorPosition(x, y);
		Console.Write("o");
		(x, y) = _snake[1];
		Console.SetCursorPosition(x, y);
		Console.Write("o");
		Console.ResetColor();
		Console.SetCursorPosition(0, 0);
	}
}

public enum Direction
{
	Up,
	Down,
	Left,
	Right
}
