using Restaurant.Models;

namespace Restaurant.DB.Repositories;

interface IOcupationRepository
{
	Ocupation Add(Ocupation ocupation);
	IEnumerable<Ocupation> GetAll();
	Ocupation? Get(int id);
	Ocupation? GetLastByCustomer(int customerId);
	Ocupation? GetLastOcupation(int table);
	Ocupation Update(Ocupation ocupation);
}
