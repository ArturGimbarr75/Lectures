using ATM.Models;

namespace ATM;

internal interface IDB
{
	Account? GetAccount(string name);
	bool AddAccount(Account account);
	bool UpdateAccount(Account account);
	bool AddCard(Card card);
	bool AddTransaction(Transaction transaction);
}