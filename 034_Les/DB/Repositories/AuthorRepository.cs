using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DB.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly Context _context;

    public AuthorRepository(Context context)
    {
        _context = context;
    }

    public async Task<Author?> GetAuthorAsync(Guid id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> AddAuthorAsync(Author author)
    {
        var result = await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Author> UpdateAuthorAsync(Author author)
    {
        var result = _context.Authors.Update(author);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Author?> DeleteAuthorAsync(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null)
        {
            return null!;
        }

        var result = _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
}