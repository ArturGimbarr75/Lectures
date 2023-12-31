﻿using _005_Les;
using System.Text;

int GetNumber(Func<int, bool>? predicate = null, string inputMsg = "Enter a number: ", string invalidMsg = "Invalid input!")
{
	predicate ??= _ => true;
	int num;

	while (true)
	{
		Console.ResetColor();
		Console.Write(inputMsg);
		Console.ForegroundColor = ConsoleColor.Green;
		string? input = Console.ReadLine();

		if (int.TryParse(input, out num) && predicate(num))
		{
			Console.ResetColor();
			break;
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(invalidMsg);
			Console.ResetColor();
		}
	}

	return num;
}

// 1.1
{
	Console.Write("Enter a text: ");
	string? text = Console.ReadLine();
	if (text is {Length: > 0 })
	{
		string textWithFirstLetterCapitalized = char.ToUpper(text[0]) + text[1..];
		Console.WriteLine(textWithFirstLetterCapitalized);
	}
	else
	{
		Console.WriteLine("Invalid text");
	}
    Console.WriteLine();
}

// 1.2
{
	Console.Write("Enter a text: ");
	string? text = Console.ReadLine();
	if (text is { Length: > 0 })
	{
		char[] textArray = text.ToCharArray();
		if (textArray.Length >= 2)
			textArray[2] = 'g';
		if (textArray.Length > 4)
			textArray[4] = 'b';
		if (textArray.Length > 6)
			textArray[6] = '*';
		if (textArray.Length > 8)
			textArray[8] = 'x';
		if (textArray.Length > 10)
			textArray[10] = 'w';
		string newText = new(textArray);
		Console.WriteLine(newText);
	}
	else
	{
		Console.WriteLine("Invalid text");
	}
    Console.WriteLine();
}

// 1.3
{
    Console.Write("Enter 5 chars: ");
	string? text = Console.ReadLine();
	if (text is { Length: 5 })
	{
		foreach (char c in text)
		{
			Console.WriteLine(
				$"""
				({c})
				dec -> {((int)c):000}
				hex -> {Convert.ToString(c, 16)}
				bin -> {Convert.ToString(c, 2)}

				""");
		}
	}
	else
	{
		Console.WriteLine("Invalid text");
	}
    Console.WriteLine();
}

// 2.1
{
	Console.Write("Enter a sentence: ");
	string? sentence = Console.ReadLine();
	string? newSentence = sentence?.Replace("a", "uo").Replace("i", "e");
	Console.WriteLine(newSentence);
    Console.WriteLine();
}

// 2.2
{
	Console.Write("Enter a sentence: ");
	string? sentence = Console.ReadLine();
    Console.Write("Which word you would like to change: ");
	string? word = Console.ReadLine();
	Console.Write("What word you would like to change it to: ");
	string? newWord = Console.ReadLine();
	if (sentence is { Length: > 0 } && word is { Length: > 0 } && newWord is { Length: > 0 })
	{
		string? newSentence = sentence?.Replace(word, newWord);
		Console.WriteLine(newSentence);
	}
	else
	{
		Console.WriteLine("Invalid text");
	}
    Console.WriteLine();
}

// 2.3
{
	Console.Write("Enter your date of birth (dd/mm/yyyy): ");
	string? dateStr = Console.ReadLine();
	if (dateStr is { Length: 10 })
	{
		string[] dateArr = dateStr.Split('/');
		if (dateArr.Length == 3)
		{
			if (int.TryParse(dateArr[0], out int day) && int.TryParse(dateArr[1], out int month) && int.TryParse(dateArr[2], out int year))
			{
				DateTime dateOfBirth = new(year, month, day);
				DateTime dateOf90thBirthday = dateOfBirth.AddYears(90);
				TimeSpan age = DateTime.Now - dateOfBirth;
				TimeSpan timeTo90thBirthday = dateOf90thBirthday - DateTime.Now;
				Console.WriteLine($"You are {age.Days / 365} years old");
				Console.WriteLine(
					$"""
					You will be 90 in
					{timeTo90thBirthday.Days / 365} years
					{timeTo90thBirthday.Days % 365 / 30} months
					{timeTo90thBirthday.Days % 365 % 30} days
					""");
			}
			else
			{
				Console.WriteLine("Invalid date");
			}
		}
		else
		{
			Console.WriteLine("Invalid date");
		}
	}
	else
	{
		Console.WriteLine("Invalid date");
	}
	Console.WriteLine();
}

// 3.1
{
	Console.Write("Enter a word: ");
	string? word = Console.ReadLine();
	if (word is { Length: > 0 })
	{
		if (word[0] is >= 'A' and <= 'Z')
		{
			Console.WriteLine("The word starts with a capital letter");
		}
		else
		{
			Console.WriteLine("The word does not start with a capital letter");
			Console.WriteLine(char.ToUpper(word[0]) + word[1..]);
        }
	}
	else
	{
		Console.WriteLine("Invalid word");
	}
    Console.WriteLine();
}

// 3.2
{
	Console.Write("Enter a word: ");
	string? word = Console.ReadLine();
	if (word is { Length: > 0 })
	{
		int[] indexesOfAllAs = word.Select((c, i) => c == 'a' ? i : -1).Where(i => i != -1).ToArray();
		Console.WriteLine($"Indexes of all 'a': {string.Join(", ", indexesOfAllAs)}");
	}
	else
	{
		Console.WriteLine("Invalid word");
	}
	Console.WriteLine();
}

// 3.3

{
	Console.Write("Enter a word: ");
	string? word = Console.ReadLine();
	if (word?.ToLower() == "hello")
	{
		Console.WriteLine(new string(word.Reverse().ToArray()));
	}
	else
	{
		Console.WriteLine("Word not 'hello'");
	}
	Console.WriteLine("Press any key to continue");
	Console.ReadKey();
}

// 4.1
{
	Console.Clear();
	int ingridient = -1; 
	float price = 0;
	StringBuilder order = new("Sandwich with:\n");
	(string ingridient, float price)[] values = new (string, float)[12]
	{
		("Black bread", 2.5f),
		("White bread", 2f),
		("Ham", 3f),
		("Cheese", 2f),
		("Tomato", 1f),
		("Cucumber", 1f),
		("Onion", 0.5f),
		("Sauce", 0.5f),
		("Hard cheese", 3f),
		("Chicken", 4f),
		("Bacon", 3f),
		("Mozarella", 3f)
	};
	Console.WriteLine("Select an ingridients of sandwich or write 0 to end order:");
	for (int i = 0; i < values.Length; i++)
		Console.WriteLine($"{i + 1}.\t{values[i].ingridient} - {values[i].price}$");

	do
	{
		ingridient = GetNumber(x => x is >= 0 and <= 12, "Enter an ingridient: ", "Invalid ingridient");
		if (ingridient != 0)
		{
			price += values[ingridient - 1].price;
			order.AppendLine($"\t{values[ingridient - 1].ingridient} ({values[ingridient - 1].price}$)");
		}
		else
			order.Append($"Price: {price}");
	}
	while (ingridient != 0);
	Console.Clear();
    Console.WriteLine(order.ToString());
	Console.WriteLine("Press any key to continue");
	Console.ReadKey();
}

// 5.1
{
	Console.Clear();
	Console.Write("Enter a phone number: ");
	string? phoneNumber = Console.ReadLine();
	// code, country, random price of minute
	(string code, string country, float priceOfMinute)[] codes =
	{
		("370", "Lithuania", 0),
		("371", "Latvia", 3.5f),
		("372", "Estonia", 3.5f),
		("375", "Belarus", 2.5f),
		("380", "Ukraine", 1.5f),
		("381", "Serbia", 4.5f),
		("382", "Montenegro", 0.5f),
		("383", "Kosovo", 1.24f),
		("385", "Croatia", 7.25f),
		("386", "Slovenia", 12.12f),
		("387", "Bosnia and Herzegovina", 1.5f),
		("389", "North Macedonia", 3.5f),
		("420", "Czech Republic", 3.5f),
		("421", "Slovakia", 0.5f),
		("423", "Liechtenstein", 0.5f),
		("500", "Falkland Islands", 0.5f),
		("501", "Belize", 0.5f),
		("502", "Guatemala", 0.5f),
		("503", "El Salvador", 0.5f),
		("504", "Honduras", 0.5f),
		("505", "Nicaragua", 0.5f),
		("506", "Costa Rica", 0.5f),
		("507", "Panama", 0.5f),
		("508", "Saint Pierre and Miquelon", 0.5f),
		("509", "Haiti", 0.5f),
		("590", "Guadeloupe", 0.5f),
		("591", "Bolivia", 0.5f),
		("592", "Guyana", 0.5f),
		("593", "Ecuador", 0.5f),
		("594", "French Guiana", 0.5f),
		("595", "Paraguay", 0.5f),
		("596", "Martinique", 0.5f),
		("597", "Suriname", 0.5f),
		("598", "Uruguay", 0.5f),
		("599", "Curaçao", 0.5f),
		("670", "Timor-Leste", 0.5f),
		("672", "Australian External Territories", 0.5f),
		("673", "Brunei", 0.5f),
		("674", "Nauru", 0.5f),
		("675", "Papua New Guinea", 0.5f),
		("676", "Tonga", 0.5f),
		("677", "Solomon", 0.5f)
	};
	if (phoneNumber is { Length: > 0 })
	{
		string countryCode = phoneNumber[1..4];
		string country = codes.FirstOrDefault(x => x.code == countryCode).country;
		if (country is not null)
		{
			Console.WriteLine($"Country: {country}");
		}
		else
		{
			Console.WriteLine("Country not found");
		}

		int minutes = GetNumber(x => x > 0, "How many minutes will be spoken: ", "Invalid minutes");
		float price = codes.FirstOrDefault(x => x.code == countryCode).priceOfMinute * minutes;
		Console.WriteLine($"Price: {price}$");
    }
	else
	{
		Console.WriteLine("Invalid phone number");
	}
	Console.WriteLine("Press any key to continue");
	Console.ReadKey();
	Console.Clear();
}

// 6
{
	const string TRUE_LOVE = "truelove";
	Console.Write("Enter a first person name: ");
	string? firstPersonName = Console.ReadLine()?.ToLower();
	Console.Write("Enter a second person name: ");
	string? secondPersonName = Console.ReadLine()?.ToLower();

	if (firstPersonName is { Length: > 0 } && secondPersonName is { Length: > 0 })
	{
		int f = TRUE_LOVE.Count(firstPersonName.Contains);
		int s = TRUE_LOVE.Count(secondPersonName.Contains);
		int sum = f * 10 + s;
		Console.WriteLine($"Love percentage: {sum}%");
		string loveDescription = sum switch
		{
			<= 30 or >= 90 => "Perfect for each other",
			>= 50 and <= 70 => "Right for each other",
			_ => "Not compatible"
		};
		Console.WriteLine(loveDescription);
	}
	else
	{
		Console.WriteLine("Invalid names");
	}
	Console.WriteLine("Press any key to continue");
	Console.ReadKey();
	Console.Clear();
}

// Project

// Simple structure of folders
Folder main = new()
{
	Name = "Main",
	Folders = new Folder[]
	{
		new()
		{
			Name = "Audio",
			Folders = new Folder[]
			{
				new()
				{
					Name = "Music",
				},
				new()
				{
					Name = "Podcasts",
				},
				new()
				{
					Name = "Audiobooks",
				}
			}
		},
		new()
		{
			Name = "Video",
			Folders = new Folder[]
			{
				new()
				{
					Name = "Movies",
					Folders = new Folder[]
					{
						new Folder()
						{
							Name = "Action",
							Folders = new Folder[]
							{
								new Folder()
								{
									Name = "John Wick",
								},
								new Folder()
								{
									Name = "Die Hard",
								},
								new Folder()
								{
									Name = "The Matrix",
								},
								new Folder()
								{
									Name = "Terminator",
								},
								new Folder()
								{
									Name = "Mission: Impossible",
								}
							}
						},
						new Folder()
						{
							Name = "Comedy",
							Folders = new Folder[]
							{
								new()
								{
									Name = "The Hangover",
								},
								new()
								{
									Name = "The Naked Gun",
								},
								new()
								{
									Name = "The Big Lebowski",
								},
								new()
								{
									Name = "Airplane!",
								},
								new()
								{
									Name = "Monty Python and the Holy Grail",
								}
							}
						},
						new Folder()
						{
							Name = "Drama",
							Folders = new Folder[]
							{
								new()
								{
									Name = "The Shawshank Redemption",
								},
								new()
								{
									Name = "The Godfather",
								},
								new()
								{
									Name = "The Dark Knight",
								},
								new()
								{
									Name = "Forrest Gump",
								},
								new()
								{
									Name = "Schindler's List",
								}
							}
						},
						new Folder()
						{
							Name = "Horror",
							Folders = new Folder[]
							{
								new()
								{
									Name = "The Shining",
								},
								new()
								{
									Name = "The Exorcist",
								},
								new()
								{
									Name = "The Thing",
								},
								new()
								{
									Name = "Alien",
								},
								new()
								{
									Name = "Halloween",
								}
							}
						},
						new Folder()
						{
							Name = "Thriller",
							Folders = new Folder[]
							{
								new()
								{
									Name = "Seven",
								},
								new()
								{
									Name = "The Silence of the Lambs",
								},
								new()
								{
									Name = "The Usual Suspects",
								},
								new()
								{
									Name = "Memento",
								},
								new()
								{
									Name = "The Departed",
								}
							}
						}
					}
				},
				new()
				{
					Name = "TV Shows",
					Folders = new Folder[]
					{
						new Folder()
						{
							Name = "Action",
						},
						new Folder()
						{
							Name = "Comedy",
						},
						new Folder()
						{
							Name = "Drama",
						},
						new Folder()
						{
							Name = "Horror",
						},
						new Folder()
						{
							Name = "Thriller",
						}
					}
				},
				new()
				{
					Name = "Video Podcasts",
					Folders = new Folder[]
					{
						new Folder()
						{
							Name = "Action",
						},
						new Folder()
						{
							Name = "Comedy",
						},
						new Folder()
						{
							Name = "Drama",
						},
						new Folder()
						{
							Name = "Horror",
						},
						new Folder()
						{
							Name = "Thriller",
						}
					}
				}
			}
		},
		new()
		{
			Name = "Documents",
			Folders = new Folder[]
			{
				new Folder()
				{
					Name = "Text",
				},
				new Folder()
				{
					Name = "PDF",
				},
				new Folder()
				{
					Name = "Word",
				},
				new Folder()
				{
					Name = "Excel",
				},
				new Folder()
				{
					Name = "PowerPoint",
				},
				new Folder()
				{
					Name = "Other",
				}
			}
		},
		new()
		{
			Name = "Images",
			Folders = new Folder[]
			{
				new Folder()
				{
					Name = "JPEG",
					Folders = new Folder[]
					{
						new()
						{
							Name = "Nature",
						},
						new()
						{
							Name = "Animals",
						},
						new()
						{
							Name = "People",
						},
						new()
						{
							Name = "Cities",
						}
					}
				},
				new Folder()
				{
					Name = "PNG",
				},
				new Folder()
				{
					Name = "GIF",
					Folders = new Folder[]
					{
						new()
						{
							Name = "Cars",
						},
						new()
						{
							Name = "Games",
						}
					}
				},
				new Folder()
				{
					Name = "Other",
				}
			}
		},
		new()
		{
			Name = "Other",
			Folders = new Folder[]
			{
				new Folder()
				{
					Name = "Archives",
				},
				new Folder()
				{
					Name = "Trash",
					Folders = new Folder[]
					{
						new()
						{
							Name = "C",
						},
						new()
						{
							Name = "C++",
						},
						new()
						{
							Name = "JS",
						}
					}
				}
			}
		}
	}
};

void SetParrent(Folder folder, Folder? parrent = null)
{
	folder.Parrent = parrent;
	foreach (Folder f in folder.Folders)
	{
		SetParrent(f, folder);
	}
}

void PrintFolder(Folder folder, int level = 0)
{
	string tab = new('\t', level);
	Console.WriteLine($"{tab}{folder.Name}");
	if (folder.Folders.Length == 0)
		return;
	Console.WriteLine($"{tab}{{");
	foreach (Folder f in folder.Folders)
		PrintFolder(f, level + 1);
	Console.WriteLine($"{tab}}}");
}

SetParrent(main);

int choice = -1;
Folder? currentFolder = main;
List<Folder> path = new() { currentFolder };
do
{
	Console.Clear();
	Console.Write("Current folder: ");
	Console.WriteLine(string.Join(" -> ", path.Select(x => x.Name)));

    int foldersCount = currentFolder?.Folders.Length ?? 0;
	for (int i = 0; i < foldersCount; i++)
		Console.WriteLine($"\t {i + 1} -> {currentFolder?.Folders[i].Name}");
	Console.WriteLine("\n\t-1 -> Back");
    Console.WriteLine("\t-2 -> Exit");

	int folderIndex = GetNumber(x => x >= -2 && x <= foldersCount + 1 && x != 0, $"Select folder (1 - {foldersCount}): ");

	switch (folderIndex)
	{
		case -2:
			choice = 0;
			break;

		case -1:
			if (currentFolder?.Parrent is not null)
			{
				currentFolder = currentFolder.Parrent;
				path.RemoveAt(path.Count - 1);
			}
			break;

		default:
			if (currentFolder?.Folders[folderIndex - 1] is not null)
			{
				currentFolder = currentFolder.Folders[folderIndex - 1];
				path.Add(currentFolder);
			}
			break;
	}
}
while (choice != 0);

Console.Clear();
PrintFolder(main);
