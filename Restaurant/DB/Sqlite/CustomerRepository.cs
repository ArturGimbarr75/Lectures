using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.DB.Sqlite;

internal class CustomerRepository : ICustomerRepository
{
    private readonly DBContext _dbContext;

    public CustomerRepository(DBContext context)
    {
        _dbContext = context;
    }

    public Customer Add(Customer customer)
	{
		Customer? existingCustomer = Get(customer.Name);
		
		if (existingCustomer is not null)
			return existingCustomer;

		_dbContext.Customers.Add(customer);
		_dbContext.SaveChanges();
		return customer;
	}

	public Customer? Get(string name)
	{
		return _dbContext.Customers.FirstOrDefault(c => c.Name == name);
	}

	public IEnumerable<Customer> GetAll()
	{
		return _dbContext.Customers.AsEnumerable();
	}

	public IEnumerable<Customer> GetAllSitingAtTables()
	{
		var customers = _dbContext.Ocupations
		.Where(o => o.End == null)
		.Select(o => o.Customer)
		.ToList();

		foreach (var customer in customers)
		{
			var ocupations = _dbContext.Ocupations
				.FirstOrDefault(o => o.Customer == customer && o.End == null);

			customer.Ocupations = new List<Ocupation> { ocupations! };
		}

		return customers;
	}

	public Customer? GetCustomerSitingAtTable(int table)
	{
        return _dbContext.Customers.FirstOrDefault(c => c.Ocupations.Any(o => o.Table == table && o.End != null));
	}
}
