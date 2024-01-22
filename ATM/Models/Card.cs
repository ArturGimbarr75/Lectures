using Newtonsoft.Json;

namespace ATM.Models;

public class Card
{
	public Guid Id { get; set; }
	public string Number { get; set; } = string.Empty;
	public string PinHash { get; set; } = string.Empty;
	public Guid AccountId { get; set; }
	[JsonIgnore]
	public virtual Account Account { get; set; } = new();
}
