internal class Snake
{
	public void Play()
	{
		Console.Clear();
		SnakeGame snake = new(50, 20);
		snake.Print();
		Direction direction = Direction.Right;
		Task.Run(() =>
		{
			while (!snake.IsGameOver)
			{
				Thread.Sleep(100);
				snake.Move(direction);
				snake.Print();
			}
		});
		while (!snake.IsGameOver)
		{
			ConsoleKey key = Console.ReadKey(intercept: true).Key;

			direction = key switch
			{
				ConsoleKey.UpArrow => Direction.Up,
				ConsoleKey.DownArrow => Direction.Down,
				ConsoleKey.LeftArrow => Direction.Left,
				ConsoleKey.RightArrow => Direction.Right,
				_ => direction,
			};
		}

		Console.SetCursorPosition(0, snake.BoardSize.Y + 1);
		Console.WriteLine($"Game over! Your score is {snake.Score * 3}.");

		var statistics = AuthorizedUser.Instance!.GamesStatistics.Snake;

		statistics.GamesPlayed++;
		statistics.Scores.Add(snake.Score * 3);

		new MockUserTable().UpdateUser(AuthorizedUser.Instance!);
	}

	private class SnakeGame
	{
		public int Score { get; private set; }
		public readonly (int X, int Y) BoardSize;
		public bool IsGameOver { get; private set; }

		private List<(int X, int Y)> _snake;
		private (int X, int Y) _food;
		private (int X, int Y) _partToRemove;

		public SnakeGame(int boardX = 10, int boardY = 10)
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
			Score = 0;
		}

		public void Move(Direction direction)
		{
			if (IsGameOver)
				return;

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
			else
				IsGameOver = true;
		}

		private void SpawnFood()
		{
			do
			{
				_food = (Random.Shared.Next(1, BoardSize.X - 1), Random.Shared.Next(1, BoardSize.Y - 1));
			}
			while (_snake.Contains(_food));
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(_food.X, _food.Y);
			Console.Write("F");
			Console.ResetColor();
		}

		private void Grow()
		{
			Score += 10;
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
}
