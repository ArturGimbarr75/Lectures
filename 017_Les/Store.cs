class Store
{
	public string Name { get; set; } = string.Empty;
	public DateTime Opened { get; set; }
	public List<string> Products { get; set; } = new();

	public Store(string name, DateTime opened)
	{
		Name = name;
		Opened = opened;
	}
}
