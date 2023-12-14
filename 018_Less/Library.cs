class Library
{
	List<string> _books = new();

	public void AddBook(string book) => _books.Add(book);

	public void RemoveBook(string book) => _books.Remove(book);

	public void PrintBooks() => Console.WriteLine(string.Join(", ", _books));
}