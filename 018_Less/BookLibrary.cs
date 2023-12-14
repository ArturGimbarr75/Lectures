class BookLibrary
{
	private List<Book> _books = new();

	public void AddBook(string title, string author, DateTime releaseDate)
	{
		_books.Add(new Book(title, author, releaseDate));
	}

	public void RemoveBook(string title)
	{
		_books.RemoveAll(book => book.Title == title);
	}

	public void PrintBooks()
	{
		foreach (Book book in _books)
			Console.WriteLine(book);
	}
}