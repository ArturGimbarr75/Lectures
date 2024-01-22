using Newtonsoft.Json;

namespace ATM.Models;

public class Transaction
{
	public Guid Id { get; set; }
	public decimal Amount { get; set; }
	public DateTime Date { get; set; }
	public Guid AccountId { get; set; }
	[JsonIgnore]
	public virtual Account Account { get; set; } = new();
	public Guid CardId { get; set; }
	[JsonIgnore]
	public virtual Card Card { get; set; } = new();
	public TransactionType TransactionType { get; set; }
}