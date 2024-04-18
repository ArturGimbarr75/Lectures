using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Repositories;

public interface IAccountRepository
{
	Task<Account?> GetAccountByIdAsync(Guid id);
	Task<Account?> GetAccountByNameAsync(string name);
	Task<IEnumerable<Account>> GetAllAccountsAsync();
	Task<Account?> AddAccountAsync(Account account);
	Task<Account?> UpdateAccountAsync(Account account);
	Task<bool> DeleteAccountAsync(Guid id);
}
