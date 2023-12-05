Snake snake = new(50, 20);
snake.Print();
Direction direction = Direction.Right;
Task GameLoop()
{
	while (true)
	{
		Thread.Sleep(100);
		snake.Move(direction);
		snake.Print();
	}
}

Task.Run(GameLoop);
while (true)
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