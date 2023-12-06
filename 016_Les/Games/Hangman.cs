internal class Hangman
{
	const int MAX_HEALTH = 8;
	string[] _words =
	{
		"HEALTH",
		"BOOK",
		"HOUSE",
		"COMPUTER",
		"PROGRAMMING",
		"TELEVISION",
		"MOUSE",
		"KEYBOARD",
		"MOUSEPAD",
		"MONITOR"
	};
	string[] _hangmans =
	{
		// 0
		"""
		 +----+ 
		 |    |  
		 |    o
		 |   /|\
		 |    |
		 |   / \
		 |
		-+--------
		""",
		// 1
		"""
		 +----+ 
		 |    |  
		 |    o
		 |   /|\
		 |    |
		 |   / 
		 |
		-+--------
		""",
		// 2
		"""
		 +----+ 
		 |    |  
		 |    o
		 |   /|\
		 |    |
		 |    
		 |
		-+--------
		""",
		// 3
		"""
		 +----+ 
		 |    |  
		 |    o
		 |   /|
		 |    |
		 |   
		 |
		-+--------
		""",
		// 4
		"""
		 +----+ 
		 |    |  
		 |    o
		 |    |
		 |    |
		 |   
		 |
		-+--------
		""",
		// 5
		"""
		 +----+ 
		 |    |  
		 |    o
		 |    
		 |    
		 |   
		 |
		-+--------
		""",
		// 6
		"""
		 +----+ 
		 |    |  
		 |    
		 |    
		 |    
		 |   
		 |
		-+--------
		""",
		// 7
		"""
		 +----+ 
		 |      
		 |    
		 |    
		 |    
		 |   
		 |
		-+--------
		""",
		// 8
		"""
		 +    
		 |      
		 |    
		 |    
		 |    
		 |   
		 |
		-+--------
		"""
	};

	public void Play()
	{
		string selectedWord = _words[Random.Shared.Next(0, _words.Length)];
		string usedLetters = "";
		int health = MAX_HEALTH;
		int guessedLetters = 0;
		char[] guessedWord = new char[selectedWord.Length];
		for (int i = 0; i < guessedWord.Length; i++)
			guessedWord[i] = '-';

		while (true)
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(_hangmans[health]);

			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = 0; i < health; i++)
				Console.Write("♥");

			Console.WriteLine();

			for (int i = 0; i < guessedWord.Length; i++)
			{
				Console.ForegroundColor = guessedWord[i] == '-' ? ConsoleColor.DarkGreen : ConsoleColor.Green;
				Console.Write(guessedWord[i]);
			}
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Used letters: ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(usedLetters);
			Console.ResetColor();

			if (!(health > 0 && guessedLetters < selectedWord.Length))
				break;

			char letter = Console.ReadKey().KeyChar;
			if (!(letter >= 'a' && letter <= 'z'))
				continue;

			letter = char.ToUpper(letter);

			if (usedLetters.Contains(letter))
				continue;

			usedLetters += letter;

			bool found = false;
			for (int i = 0; i < selectedWord.Length; i++)
			{
				if (selectedWord[i] == letter)
				{
					guessedWord[i] = letter;
					guessedLetters++;
					found = true;
				}
			}

			if (!found)
				health--;
		}

		if (health > 0)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("You won!");
			AuthorizedUser.Instance!.GamesStatistics.Hangman.GamesWon++;
			AuthorizedUser.Instance!.GamesStatistics.Hangman.Scores.Add(health * 2);
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"You lost! Word: {selectedWord}");
			AuthorizedUser.Instance!.GamesStatistics.Hangman.GamesLost++;
			AuthorizedUser.Instance!.GamesStatistics.Hangman.Scores.Add(-5);
		}

		new MockUserTable().UpdateUser(AuthorizedUser.Instance!);
		Console.ResetColor();
	}
}
