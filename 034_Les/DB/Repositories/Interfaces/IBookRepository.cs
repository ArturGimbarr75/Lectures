using Models;

namespace DB.Repositories.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetBookAsync(Guid id);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
	Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task<Book?> DeleteBookAsync(Guid id);
}
