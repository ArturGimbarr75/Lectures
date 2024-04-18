using _041_Les_Car_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _041_Les_Car_API.Repositories.EF;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetAccountByIdAsync(Guid id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account?> GetAccountByNameAsync(string name)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.Name == name);
    }

    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> AddAccountAsync(Account account)
    {
        var result = await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Account?> UpdateAccountAsync(Account account)
    {
        var result = _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteAccountAsync(Guid id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account is null)
        {
            return false;
        }
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
        return true;
    }
}
