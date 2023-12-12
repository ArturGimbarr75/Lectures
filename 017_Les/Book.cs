// 1_1

// 1_2

// 1_3

// 1_4

// 2_1

// 2_2
class Book
{
	public string Title { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public string Country { get; set; } = string.Empty;
	public DateTime ReleaseDate { get; set; }

	public Book(string title, string author, DateTime releaseDate)
	{
		Title = title;
		Author = author;
		ReleaseDate = releaseDate;
	}

	public Book(string title, string author, string country, DateTime releaseDate) : this(title, author, releaseDate)
	{
		Country = country;
	}
}

