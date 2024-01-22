namespace ATM.Models;

public class Account
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	
	public decimal Balance { get; set; }
	public List<Card> Cards { get; set; } = new();
	public List<Transaction> Transactions { get; set; } = new();

	public int TransactionLimitPerDay { get; set; }
}
