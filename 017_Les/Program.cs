// 1_1
{
	Person p1 = new();

    Console.WriteLine($"Name: {p1.Name}\nAge: {p1.Age}");
}

// 1_2
{
	Person p1 = new(1.8f);

	Console.WriteLine($"Name: {p1.Name}\nAge: {p1.Age}\nHeight: {p1.Height}");
}

// 1_3
{
	School school = new("Hogwarts", "London");
    Console.WriteLine($"School: {school.Name}\nCity: {school.City}");
}

// 1_4
{
	School school = new("Hogwarts", "London", 1000);
	Console.WriteLine($"School: {school.Name}\nCity: {school.City}\nStudents count: {school.StudentsCount}");
}

// 2_1
{
	Book book = new("Harry Potter and the Philosopher's Stone", "J. K. Rowling", new(1997, 6, 26));
	Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nRelease date: {book.ReleaseDate}");
}

// 2_2
{
	Book book = new("Harry Potter and the Philosopher's Stone", "J. K. Rowling", "United Kingdom", new(1997, 6, 26));
	Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nCountry: {book.Country}\nRelease date: {book.ReleaseDate}");
}

// 2_3
{
	List<Book> books = new()
	{
		new("Harry Potter and the Philosopher's Stone", "J. K. Rowling", "United Kingdom", new(1997, 6, 26)),
		new("Harry Potter and the Chamber of Secrets", "J. K. Rowling", "United Kingdom", new(1998, 7, 2)),
		new("Harry Potter and the Prisoner of Azkaban", "J. K. Rowling", "United Kingdom", new(1999, 7, 8)),
		new("Harry Potter and the Goblet of Fire", "J. K. Rowling", "United Kingdom", new(2000, 7, 8)),
		new("Harry Potter and the Order of the Phoenix", "J. K. Rowling", "United Kingdom", new(2003, 6, 21)),
		new("Harry Potter and the Half-Blood Prince", "J. K. Rowling", "United Kingdom", new(2005, 7, 16)),
		new("Harry Potter and the Deathly Hallows", "J. K. Rowling", "United Kingdom", new(2007, 7, 21)),
		new("Harry Potter and the Cursed Child", "J. K. Rowling", "United Kingdom", new(2016, 7, 31)),
		new("C# 9 and .NET 5 - Modern Cross-Platform Development", "Mark J. Price", "United States", new(2020, 11, 25)),
		new("Pro .NET 5 Apps - Building Cross-Platform .NET Apps", "Mark J. Price", "United States", new(2021, 1, 20)),
		new("Pro ASP.NET Core MVC 2", "Adam Freeman", "United Kingdom", new(2017, 7, 27)),
		new("Pro ASP.NET Core 3", "Adam Freeman", "United Kingdom", new(2020, 1, 31)),
		new("Pro ASP.NET Core MVC 6", "Adam Freeman", "United Kingdom", new(2016, 10, 27)),
	};

	List<Book> GetBooksOfAuthor(List<Book> books, string author)
	{
		List<Book> booksOfAuthor = new();
		foreach (Book book in books)
			if (book.Author == author)
				booksOfAuthor.Add(book);
		return booksOfAuthor;
	}

	List<Book> booksOfAuthor = GetBooksOfAuthor(books, "J. K. Rowling");
    Console.WriteLine("Books of J. K. Rowling:");
    foreach (Book book in booksOfAuthor)
		Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nCountry: {book.Country}\nRelease date: {book.ReleaseDate}");
}

// 2_4
{
	Store store = new("Walmart", new(1962, 7, 2))
	{
		Products = new()
		{
			"Food",
			"Clothes",
			"Electronics",
			"Home appliances",
			"Books",
			"Movies",
			"Music"
		}
	};

	Console.WriteLine($"Store: {store.Name}\nOpened: {store.Opened}\nProducts:");
	foreach (string product in store.Products)
		Console.WriteLine(product);
}

// 3_1 - 3_2
{
	string[] GetAnimalNames(params AnimalBase[] animals)
	{
		string[] names = new string[animals.Length];
		for (int i = 0; i < animals.Length; i++)
			names[i] = animals[i].Name;
		return names;
	}

	AnimalBase[] animals = new AnimalBase[]
	{
		new Cat("Felix"),
		new Dog("Rex"),
		new Hamster("Duda")
	};

	string[] names = GetAnimalNames(animals);
	Console.WriteLine("Animal names:");
	foreach (string name in names)
		Console.WriteLine(name);
}

// 3_3
{
	ShapeBase[] shapes =
	{
		new Circle(5),
		new Rectangle(5, 10),
		new Square(5),
		new Triangle(5, 10, 10),
		new Rhombus(5, 10)
	};

	foreach (ShapeBase shape in shapes)
		Console.WriteLine($"{shape.Name} peimeter: {shape.Perimeter:0.00}; area: {shape.Area:0.00}");
}