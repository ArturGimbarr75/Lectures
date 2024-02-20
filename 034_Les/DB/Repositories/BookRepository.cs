using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DB.Repositories;

public class BookRepository : IBookRepository
{
    private readonly Context _context;

    public BookRepository(Context context)
    {
        _context = context;
    }

    public async Task<Book?> GetBookAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        var result = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        var result = _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Book?> DeleteBookAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return null;
        }

        var result = _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

	public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId)
    {
        return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
    }
}
