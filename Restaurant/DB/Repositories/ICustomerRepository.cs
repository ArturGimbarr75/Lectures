using Restaurant.Models;

namespace Restaurant.DB.Repositories;

interface ICustomerRepository
{
	Customer? GetCustomerSitingAtTable(int tableNumber);
	Customer Add(Customer customer);
	IEnumerable<Customer> GetAll();
	IEnumerable<Customer> GetAllSitingAtTables();
	Customer? Get(string name);
}
