using Models;

namespace DB.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<Author?> GetAuthorAsync(Guid id);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> AddAuthorAsync(Author author);
    Task<Author> UpdateAuthorAsync(Author author);
    Task<Author?> DeleteAuthorAsync(Guid id);
}
