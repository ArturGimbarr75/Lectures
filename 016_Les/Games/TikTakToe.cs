internal class TikTakToe
{
	public void Play()
	{
		char[,] board = new char[3, 3];
		int turn = 0;
		bool gameEnded = false;
		char winner = '\0';

		while (!gameEnded)
		{
			Console.Clear();
			DrawBoard(board);
			Console.WriteLine();
			if (turn % 2 == 0)
			{
				Console.WriteLine("Player turn");

				Console.WriteLine("Enter a number between 1 and 9 to place your mark");
				int choice = ChooseNumber(board);
				int x = (choice - 1) / 3;
				int y = (choice - 1) % 3;
				if (turn % 2 == 0)
					board[x, y] = 'X';
				else
					board[x, y] = 'O';
				turn++;
			}
			else
			{
				Console.WriteLine("AI turn");

				int choice = 0;
				int x = 0, y = 0;
				while (choice == 0)
				{
					choice = new Random().Next(1, 10);
					x = (choice - 1) / 3;
					y = (choice - 1) % 3;
					if (board[x, y] != '\0')
						choice = 0;
				}

				board[x, y] = 'O';
				turn++;
			}

			(bool ended, winner) = CheckForWin(board);
			if (ended || turn == 9)
				gameEnded = true;
		}

		Console.Clear();
		DrawBoard(board);

		var statistics = AuthorizedUser.Instance!.GamesStatistics;

        if (turn == 9)
		{
			Console.WriteLine("Draw");
		}
		else
		{
			if (winner == 'X')
			{
				Console.WriteLine("Player won");
				statistics.TikTakToe.GamesWon++;
				statistics.TikTakToe.Scores.Add(10);
			}
			else
			{
				Console.WriteLine("AI won");
				statistics.TikTakToe.GamesLost++;
				statistics.TikTakToe.Scores.Add(-5);
			}
		}
		statistics.TikTakToe.GamesPlayed++;
		new MockUserTable().UpdateUser(AuthorizedUser.Instance);
	}

	private void DrawBoard(char[,] board)
	{
		Console.WriteLine("  1 2 3");
		for (int i = 0; i < 3; i++)
		{
			Console.Write($"{i + 1} ");
			for (int j = 0; j < 3; j++)
			{
				if (board[i, j] == '\0')
					Console.Write("_");
				else
					Console.Write(board[i, j]);
				if (j != 2)
					Console.Write("|");
			}
			Console.WriteLine();
		}
	}

	private int ChooseNumber(char[,] board)
	{
		int choice = 0;
		while (choice == 0)
		{
			choice = Choose(9);
			int x = (choice - 1) / 3;
			int y = (choice - 1) % 3;
			if (board[x, y] != '\0')
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("This field is already taken");
				Console.ResetColor();
				choice = 0;
			}
		}

		return choice;
	}

	private (bool, char) CheckForWin(char[,] board)
	{
		if (board[0, 0] != '\0' && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
			return (true, board[0, 0]);
		if (board[1, 0] != '\0' && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
			return (true, board[1, 0]);
		if (board[2, 0] != '\0' && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
			return (true, board[2, 0]);
		if (board[0, 0] != '\0' && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
			return (true, board[0, 0]);
		if (board[0, 1] != '\0' && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
			return (true, board[0, 1]);
		if (board[0, 2] != '\0' && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
			return (true, board[0, 2]);
		if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
			return (true, board[0, 0]);
		if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
			return (true, board[0, 2]);
		return (false, '\0');
	}

	private int Choose(int count)
	{
		int result;
		Console.Write("Choice: ");
		string choice = Console.ReadLine() ?? "";
		while (!(int.TryParse(choice, out result) && result > 0 && result <= count))
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Invalid choice");
			Console.ResetColor();
			choice = Console.ReadLine() ?? "";
		}

		return result;
	}
}
