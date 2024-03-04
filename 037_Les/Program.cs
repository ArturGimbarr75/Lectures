using Dapper;
using System;
using System.Data.SqlClient;

string connectionString = "Server=(localDB)\\MSSQLLocalDB;Database=Les37;";
var repository = new PersonRepository(connectionString);

Person person = new()
{
    Name = "John",
    Surname = "Doe",
    BirthDate = new DateTime(1980, 1, 1)
};

var id = await repository.AddAsync(person);
Console.WriteLine($"Added person with id: {id}");

Person[] people = new[]
{
    new Person { Name = "Jane", Surname = "Doe", BirthDate = new DateTime(1982, 2, 2) },
    new Person { Name = "Jack", Surname = "Doe", BirthDate = new DateTime(1984, 3, 3) },
    new Person { Name = "Jill", Surname = "Doe", BirthDate = new DateTime(1986, 4, 4) },
    new Person { Name = "James", Surname = "Doe", BirthDate = new DateTime(1988, 5, 5) }
};

foreach (var p in people)
{
    await repository.AddAsync(p);
}

var allPeople = await repository.GetAllAsync();

foreach (var p in allPeople)
{
    Console.WriteLine($"{p.Id} {p.Name} {p.Surname} {p.BirthDate}");
}

var personById = await repository.GetByIdAsync(1);
Console.WriteLine("Person by id: 1");
Console.WriteLine($"{personById?.Id} {personById?.Name} {personById?.Surname} {personById?.BirthDate}");


public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
}

public class PersonRepository
{
    private readonly string _connectionString;

    public PersonRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> AddAsync(Person person)
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = "spAddPerson";
        var parameters = new { person.Name, person.Surname, person.BirthDate, person.DeathDate };
        var id = await connection.QuerySingleAsync<int>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
        return id;
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = "spGetPersonById";
        return await connection.QuerySingleOrDefaultAsync<Person>(sql, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = "spGetAllPersons";
        return await connection.QueryAsync<Person>(sql, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(Person person)
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = "spUpdatePerson";
        var parameters = new { person.Id, person.Name, person.Surname, person.BirthDate, person.DeathDate };
        await connection.ExecuteAsync(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = "spDeletePerson";
        await connection.ExecuteAsync(sql, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
    }
}
