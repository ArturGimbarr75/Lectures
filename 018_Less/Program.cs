// 1_1
{
	NumberHolder numberHolder = new();
	numberHolder.Add(1);
	numberHolder.Add(2);
	numberHolder.Add(3);
	numberHolder.Print();
}

// 1_2
{
	Rectangle rectangle = new(5, 10);
	Console.WriteLine($"Rectangle area: {rectangle.GetArea()}; perimeter: {rectangle.GetPerimeter()}");
}

// 1_3
{
	Circle circle = new(5);
	Console.WriteLine($"Circle area: {circle.GetArea()}; perimeter: {circle.GetPerimeter()}");
}

// 1_4
{
	Library library = new();
	library.AddBook("Book 1");
	library.AddBook("Book 2");
	library.AddBook("Book 3");
	library.PrintBooks();
	library.RemoveBook("Book 2");
	library.PrintBooks();
}

// 1_5
{
	BookLibrary bookLibrary = new();
	bookLibrary.AddBook("Book 1", "Author 1", new DateTime(2012, 12, 21));
	bookLibrary.AddBook("Book 2", "Author 2", new DateTime(2013, 12, 21));
	bookLibrary.AddBook("Book 3", "Author 3", new DateTime(2014, 12, 21));
	bookLibrary.PrintBooks();
	bookLibrary.RemoveBook("Book 2");
	bookLibrary.PrintBooks();
}