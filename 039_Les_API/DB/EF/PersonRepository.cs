using _039_Les_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _039_Les_API.DB.EF;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        return await _context.People.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person> CreatePerson(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> UpdatePerson(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task DeletePerson(Guid id)
    {
        var person = await GetPerson(id);
        if (person is not null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
