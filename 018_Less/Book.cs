class Book
{
	public string Title { get; set; }
	public string Author { get; set; }
	public DateTime ReleaseDate { get; set; }

	public Book(string title, string author, DateTime releaseDate)
	{
		Title = title;
		Author = author;
		ReleaseDate = releaseDate;
	}

	override public string ToString()
	{
		return $"Title: {Title}\nAuthor: {Author}\nRelease date: {ReleaseDate}";
	}
}
