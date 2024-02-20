using DB.Repositories;
using DB.Repositories.Interfaces;
using Models;
using System.Linq;

Console.WriteLine("Start DB");

using Context context = new();

IAuthorRepository authorRepository = new AuthorRepository(context);
IBookRepository bookRepository = new BookRepository(context);

// await FillData(authorRepository, bookRepository);
// await AddRandomData(authorRepository, bookRepository, 1000, 1000);
await PrintData(authorRepository, bookRepository, 10);

Console.WriteLine("End DB");

static async Task FillData(IAuthorRepository authorRepository, IBookRepository bookRepository)
{
	var author1 = new Author
	{
		Id = Guid.NewGuid(),
		Name = "Author 1",
		Surname = "Surname 1",
		Books = new List<Book>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Title = "Book 1",
				Description = "Description 1",
				Content = "Content 1",
				AuthorId = Guid.NewGuid()
			},
			new()
			{
				Id = Guid.NewGuid(),
				Title = "Book 2",
				Description = "Description 2",
				Content = "Content 2",
				AuthorId = Guid.NewGuid()
			}
		}
	};

	var author2 = new Author
	{
		Id = Guid.NewGuid(),
		Name = "Author 2",
		Surname = "Surname 2",
		Books = new List<Book>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Title = "Book 3",
				Description = "Description 3",
				Content = "Content 3",
				AuthorId = Guid.NewGuid()
			},
			new()
			{
				Id = Guid.NewGuid(),
				Title = "Book 4",
				Description = "Description 4",
				Content = "Content 4",
				AuthorId = Guid.NewGuid()
			}
		}
	};

	await authorRepository.AddAuthorAsync(author1);
	await authorRepository.AddAuthorAsync(author2);
}

static async Task AddRandomData(IAuthorRepository authorRepository, IBookRepository bookRepository, int authorsCount = 1000, int booksCount = 1000)
{
	for (int i = 0; i < authorsCount; i++)
	{
		var author = new Author
		{
			Id = Guid.NewGuid(),
			Name = $"Author {i}",
			Surname = $"Surname {i}",
			Books = new List<Book>()
		};

		for (int j = 0; j < booksCount; j++)
		{
			author.Books.Add(new Book
			{
				Id = Guid.NewGuid(),
				Title = $"Book {j}",
				Description = $"Description {j}",
				Content = $"Content {j}",
				AuthorId = author.Id
			});
		}

		await authorRepository.AddAuthorAsync(author);
	}
}

static async Task PrintData(IAuthorRepository authorRepository, IBookRepository bookRepository, int count = 10)
{
	IEnumerable<Author> authors = (await authorRepository.GetAuthorsAsync()).Take(count);

	foreach (var author in authors)
	{
		await Console.Out.WriteLineAsync($"Author: {author.Name} {author.Surname}");
		await Console.Out.WriteLineAsync($"\tBooks:");

		IEnumerable<Book> books = (await bookRepository.GetBooksByAuthorIdAsync(author.Id)).Take(count);
		foreach (var book in books)
			await Console.Out.WriteLineAsync($"\tTitle: {book.Title}, Description: {book.Description}\n\tContent: {book.Content}");
	}
}
	