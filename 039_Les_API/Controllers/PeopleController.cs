using _039_Les_API.DB;
using _039_Les_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace _039_Les_API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class PeopleController : ControllerBase
{
	private readonly ILogger<PeopleController> _logger;
	private readonly IPersonRepository _personRepository;

	public PeopleController(ILogger<PeopleController> logger, IPersonRepository personRepository)
	{
		_logger = logger;
		_personRepository = personRepository;
	}

	[HttpGet(Name = "GetPeople")]
	public async Task<IEnumerable<Person>> GetPeople()
	{
		return await _personRepository.GetPeople();
	}

	[HttpGet("{id}", Name = "GetPerson")]
	public async Task<Person?> GetPerson(Guid id)
	{
		return await _personRepository.GetPerson(id);
	}

	[HttpPost(Name = "CreatePerson")]
	public async Task<Person> CreatePerson(Person person)
	{
		return await _personRepository.CreatePerson(person);
	}

	[HttpPut(Name = "UpdatePerson")]
	public async Task<Person> UpdatePerson(Person person)
	{
		return await _personRepository.UpdatePerson(person);
	}

	[HttpDelete("{id}", Name = "DeletePerson")]
	public async Task DeletePerson(Guid id)
	{
		await _personRepository.DeletePerson(id);
	}
}
