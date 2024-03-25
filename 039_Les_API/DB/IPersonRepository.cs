using _039_Les_API.Models;

namespace _039_Les_API.DB;

public interface IPersonRepository
{
	Task<IEnumerable<Person>> GetPeople();
	Task<Person?> GetPerson(Guid id);
	Task<Person> CreatePerson(Person person);
	Task<Person> UpdatePerson(Person person);
	Task DeletePerson(Guid id);
}
