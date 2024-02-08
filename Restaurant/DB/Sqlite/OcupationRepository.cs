using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.DB.Sqlite;

internal class OcupationRepository : IOcupationRepository
{
	private readonly DBContext _dbContext;

	public OcupationRepository(DBContext context)
	{
		_dbContext = context;
	}

	public Ocupation Add(Ocupation ocupation)
	{
		_dbContext.Ocupations.Add(ocupation);
		_dbContext.SaveChanges();
		return ocupation;
	}

	public Ocupation? Get(int id)
	{
		return _dbContext.Ocupations.FirstOrDefault(o => o.Id == id);
	}

	public IEnumerable<Ocupation> GetAll()
	{
		return _dbContext.Ocupations.AsEnumerable();
	}

	public Ocupation? GetLastByCustomer(int customerId)
	{
		return _dbContext.Ocupations
				.Where(o => o.Customer.Id == customerId)
				.OrderByDescending(o => o.Start)
				.FirstOrDefault();
	}

	public Ocupation? GetLastOcupation(int table)
	{
		return _dbContext.Ocupations
				.Where(o => o.Table == table)
				.OrderByDescending(o => o.Start)
				.FirstOrDefault();
	}

	public Ocupation Update(Ocupation ocupation)
	{
		var ocupationToUpdate = Get(ocupation.Id);
		
		if (ocupationToUpdate is null)
			return ocupation;

		ocupationToUpdate.Start = ocupation.Start;
		ocupationToUpdate.Table = ocupation.Table;
		ocupationToUpdate.End = ocupation.End;
		ocupationToUpdate.Customer = ocupation.Customer;

		_dbContext.SaveChanges();
		return ocupationToUpdate;
	}
}
